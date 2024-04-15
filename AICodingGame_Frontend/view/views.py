from django.shortcuts import render
import json
import requests as r

BASE_URL = 'http://localhost'

def mainPage(request):
    return render(request, 'welcome.html')

def robotsView(request):
    robots = json.loads(r.get(f"{BASE_URL}/api/Robot/getRobots").content)
    return render(request, 'robots.html', {'robots': robots})
    
def battlesView(request):
    battles = json.loads(r.get(f"{BASE_URL}/api/Battle/getBattles").content)
    return render(request, 'battles.html', {'battles': battles})

def docsView(request):
    return render(request, 'docs.html')