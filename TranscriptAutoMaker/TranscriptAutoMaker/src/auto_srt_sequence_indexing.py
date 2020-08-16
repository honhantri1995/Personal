import re

pattern = r"^0(?:.+[\n\r])+"

with open('D:\\CODE\\GIT\\Personal\\TranscriptAutoMaker\\TranscriptAutoMaker\\transcripts\\I quit social media for 30 days.srt') as f:
    text = f.read()

# print(text)

p = re.compile(pattern, re.MULTILINE)
result = p.findall(text)
print(result)

# print(re.findall(pattern, text))
# text_list  = re.split(pattern, text)
with open('D:\\CODE\\GIT\\Personal\\TranscriptAutoMaker\\TranscriptAutoMaker\\transcripts\\I quit social media for 30 days - after.srt', "w") as f:
    i = 1
    text = ''
    for t in result:
        text = str(i) + '\n' + t + '\n'
        f.write(text)
        i += 1
