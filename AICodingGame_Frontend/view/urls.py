from django.urls import path

from . import views

urlpatterns = [
    path('', views.mainPage),
    path('robots', views.robotsView),
    path('robots/add', views.robotAddView),
    path('battles', views.battlesView),
    path('docs', views.docsView)
]