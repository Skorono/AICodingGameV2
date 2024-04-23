import aiohttp
import asyncio
import datetime
from django.shortcuts import render
import json
import requests as r
import datetime
import view.helpers.ImageConverter as img
from . import forms
from django.conf import settings
import os

BASE_URL = 'http://localhost'

def mainPage(request):
    return render(request, 'welcome.html')

def robotsView(request):
    robots = json.loads(r.get(f"{BASE_URL}/api/Robot/get").content)
    return render(request, 'robots.html', {'robots': robots})
    
async def robotAddView(request):
    if request.method == "POST":
        form = forms.RobotForm(request.POST, request.FILES)
        if form.is_valid():
            name = form.cleaned_data["name"]
            projectPath = form.cleaned_data["path"]
            imageFile = form.cleaned_data["image"]
            imageBytes = imageFile.read() 
            print(await send_data_async("http://localhost/api/Robot/add", data = {
                "Name": str(name),
                "ProjectPath": str(projectPath),
                "Image": str(imageBytes),
                "LastUpdated": datetime.datetime.now().isoformat()
            }))
    else:
        form = forms.RobotForm()
    return render(request, 'robotAdd.html', {"form": form})
    
def battlesView(request):
    battles = json.loads(r.get(f"{BASE_URL}/api/Battle/get").content)
    for battle in battles:
        battle["startDateTime"] = datetime.datetime.fromisoformat(battle["startDateTime"])
        battle["endDateTime"] = datetime.datetime.fromisoformat(battle["endDateTime"])
    return render(request, 'battles.html', {'battles': battles})

def docsView(request):
    return render(request, 'docs.html')

async def send_data_async(url, data):
    async with aiohttp.ClientSession() as session:
        async with session.post(url, json=data) as response:
            return await response.text()