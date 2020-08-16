from punctuator import Punctuator
p = Punctuator('D:\\CODE\\GIT\\Personal\\TranscriptAutoMaker\\TranscriptAutoMaker\\packages\\Demo-Europarl-EN.pcl')
file = open('D:\\CODE\\GIT\\Personal\\TranscriptAutoMaker\\TranscriptAutoMaker\\transcripts\\I quit social media for 30 days - bk.srt')
text = file.read()

print(p.punctuate(text))