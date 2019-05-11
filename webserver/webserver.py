from flask import *
from flask_apscheduler import APScheduler
from flask_socketio import SocketIO, emit
from werkzeug import secure_filename
import cv2
import os

app = Flask(__name__)

scheduler = APScheduler()
scheduler.init_app(app)
scheduler.start()

socketio = SocketIO(app)

app_directory = os.getcwd()

# Check for new file
def checkForNewVideos():
	files = os.listdir(os.path.join(app_directory, 'videos'))

	for file in files:
		if file.endswith('.MOV'):
			try:
				generateDataset(file)
				os.remove(os.path.join(app_directory, 'videos', file))
			except:
				pass

def generateDataset(file):
	print('GENERATING THE WORLD OR SOMETHING')

# Check for any problems (maybe send pictures if there are any)
@socketio.on('check')
def check(data):
	problem = True
	if problem:
		emit('message', {'data': 'AH'})
	else:
		pass

# Upload file
@app.route('/test', methods=['POST'])
def test():
	uploaded_file = request.files['uploaded_file']
	uploaded_file.save(os.path.join(app_directory, 'videos', secure_filename(uploaded_file.filename)))
	return 'OK'

@app.route('/')
def index():
	return render_template('index.html')

if __name__ == '__main__':
	app.apscheduler.add_job(func=checkForNewVideos, trigger='interval', seconds=1, id='1')
	app.run(host='0.0.0.0', debug=True)
