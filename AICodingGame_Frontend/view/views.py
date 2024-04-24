import aiohttp
import asyncio
import datetime
from django.shortcuts import render
import json
import requests as r
import datetime
import os
import view.helpers.ImageConverter as img
from . import forms
from django.conf import settings
from http import HTTPStatus

BASE_URL = 'http://localhost'

def mainPage(request):
    return render(request, 'welcome.html')

def robotsView(request):
    data = {}
    try:
        response = r.get(f"{BASE_URL}/api/Robot/get")
        if response.status_code == HTTPStatus.OK:
            data["robots"] = json.loads(response.content)
    finally:
        return render(request, 'robots.html', data)
    
async def robotAddView(request):
    if request.method == "POST":
        form = forms.RobotForm(request.POST, request.FILES)
        if form.is_valid():
            name = form.cleaned_data["name"]
            projectPath = form.cleaned_data["folderPath"]
            imageFile = form.cleaned_data["image"]
            imageBytes = imageFile.read() 
            print(await send_data_async(f"{BASE_URL}api/Robot/add", data = {
                "name": str(name),
                "projectPath": str(projectPath),
                "image": str(imageBytes),
                "lastUpdated": datetime.datetime.now().isoformat()
            }))
    else:
        form = forms.RobotForm()
    return render(request, 'robotAdd.html', {"form": form})
    
def battlesView(request):
    data = {}
    try:
        battles = json.loads(r.get(f"{BASE_URL}/api/Battle/get").content)
        for battle in battles:
            battle["startDateTime"] = datetime.datetime.fromisoformat(battle["startDateTime"])
            battle["endDateTime"] = datetime.datetime.fromisoformat(battle["endDateTime"])
        data["battles"] = battles
    except:
        pass
    finally:
        return render(request, 'battles.html', data)

def docsView(request):
    return render(request, 'docs.html')

async def send_data_async(url, data):
    try:
        async with aiohttp.ClientSession() as session:
            async with session.post(url, json=data) as response:
                return await response.status
    except:
        return None