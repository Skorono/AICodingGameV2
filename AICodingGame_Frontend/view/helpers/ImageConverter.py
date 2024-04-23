from PIL import Image
from io import BytesIO
from os.path import exists
from os import open


class ImageConverter:
    def imageToBytes(self, path):
        if (path != None) and exists(path):
            with open(path, mode="rb") as image:
                return bytearray(image.read())
        return None

    def bytesToImage(self, byte_array):
        if byte_array:
            image = Image.open(BytesIO(byte_array))
            return image
        return None