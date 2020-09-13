import re

pattern = r"^0(?:.+[\n\r])+"
input_srt = r'path\to\input\srt\sub'
output_srt = r'path\to\output\srt\sub'

with open(input_srt) as f:
    text = f.read()

p = re.compile(pattern, re.MULTILINE)
result = p.findall(text)
print(result)

with open(output_srt, "w") as f:
    i = 1
    text = ''
    for t in result:
        text = str(i) + '\n' + t + '\n'
        f.write(text)
        i += 1
