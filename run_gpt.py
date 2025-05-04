import os
import re
import textwrap
from openai import OpenAI

client = OpenAI(api_key=os.getenv("OPENAI_API_KEY"))
task = os.getenv("GPT_TASK")

system_prompt = textwrap.dedent("""\
    Ты — помощник Unity-разработчика. 
    Если задача требует создать или изменить код, возвращай его в формате:

    [FILE: путь/к/файлу.cs]
    <код файла>

    Только указывай нужные файлы, без пояснений и описаний. Не добавляй Markdown, таких как ```csharp.
""")

response = client.chat.completions.create(
    model="gpt-4o",
    messages=[
        {"role": "system", "content": system_prompt},
        {"role": "user", "content": task}
    ]
)

content = response.choices[0].message.content

with open("GPT_Response.md", "w", encoding="utf-8") as f:
    f.write(content)

matches = re.findall(r'\[FILE: (.*?)\]\n(.+?)(?=\n\[FILE: |\Z)', content, flags=re.DOTALL)

for filepath, code in matches:
  full_path = filepath.strip()
  dir_name = os.path.dirname(full_path)
  if dir_name:
      os.makedirs(dir_name, exist_ok=True)
  with open(full_path, "w", encoding="utf-8") as f:
      f.write(code.strip())
