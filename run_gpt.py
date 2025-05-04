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

    Если задача предполагает какие-либо действия в Unity (даже визуальные эффекты, сцену, постобработку и т.д.), ты **обязан вернуть хотя бы один файл** с кодом или конфигурацией или все файлы, которые зависят друг от друга и требуются для запуска.

    Даже если ты не уверен, создай заглушку, комментарии, примерный шаблон с максимум кода. Не добавляй объяснений, не используй Markdown (никаких ```csharp и т.п.).

    Никогда не отвечай описательно. Только список файлов и их содержимое в указанном формате.
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
