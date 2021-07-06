from flask import Flask
from flask_restful import Resource, Api, reqparse
import werkzeug, os
from keras.preprocessing.image import load_img
from keras.preprocessing.image import img_to_array
from keras.models import load_model
import json

app = Flask(__name__)
api = Api(app)
UPLOAD_FOLDER = 'static/img'
parser = reqparse.RequestParser()
parser.add_argument('file',
    type=werkzeug.datastructures.FileStorage,
    location='files')

class PhotoUpload(Resource):
    def post(self):
        data = parser.parse_args()
        if data['file'] == None:
            return "no file"
        photo = data['file']

        if photo:
            filename = 'received.jpg'
            photo.save(os.path.join(UPLOAD_FOLDER, filename))
            
            full_path = UPLOAD_FOLDER + '/' + filename
            
            print("FILE PATH: " + full_path)
            
            img = self.load_image(full_path)
            
            result = model.predict(img)
            return str(result[0][0])

    def load_image(self, filename):
        # load the image
        img = load_img(filename, target_size=(224, 224))
        # convert to array
        img = img_to_array(img)
        # reshape into a single sample with 3 channels
        img = img.reshape(1, 224, 224, 3)
        # center pixel data
        img = img.astype('float32')
        img = img - [123.68, 116.779, 103.939]
        return img

api.add_resource(PhotoUpload, '/upload')

if __name__ == '__main__':
    model = load_model('final_model.h5')
    app.run(debug=True)
