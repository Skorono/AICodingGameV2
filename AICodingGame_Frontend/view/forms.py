from django import forms


class RobotForm(forms.Form):
    image = forms.ImageField(
        required=False
    )
    
    name = forms.CharField(
        help_text="Name", 
        required=True, 
        max_length=100
    )
    
    filesPath = forms.FilePathField(
        path = '/',
        required = True,
        label='Select a folder',
        allow_files = False,
        allow_folders = True,
        widget=forms.TextInput(
            attrs={
                'type': 'file',
                "id": "folder-input",
                "webkitdirectory directory multiple onchange": "handleFolderChange(event)"
            }
        )
    )
    
    folderPath = forms.CharField(widget=forms.HiddenInput())

    def __init__(self, *args, **kwargs):
        super(RobotForm, self).__init__(*args, **kwargs)
        self.fields['name'].widget.attrs.update({'class': 'form-control'})
        self.fields['image'].widget.attrs.update({'id': 'image-input', 'class': 'form-control'})
        self.fields['filesPath'].widget.attrs.update({'class': 'form-control'})
        
        