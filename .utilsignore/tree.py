import os
import json


def load_config(path="./.treeignore.json"):
    print(f"Path: {path}")
    if os.path.exists(path):
        with open(path, "r") as f:
            config = json.load(f)
            print(f"Config: {json.dumps(config)}")
            return (
                config.get("exclude_dirs", []),
                config.get("exclude_files", []),
                config.get("exclude_extensions", []),
            )
    return [], [], []


def print_tree(
    start_path=".",
    prefix="",
    exclude_dirs=None,
    exclude_files=None,
    exclude_extensions=None,
):
    exclude_dirs = exclude_dirs or []
    exclude_files = exclude_files or []
    exclude_extensions = exclude_extensions or []

    try:
        entries = sorted(os.listdir(start_path))
    except PermissionError:
        print("permission error?")
        return

    filtered_entries = []
    for entry in entries:
        if entry.startswith(".") or entry == "__pycache__":
            continue

        path = os.path.join(start_path, entry)
        is_dir = os.path.isdir(path)
        is_file = os.path.isfile(path)
        _, ext = os.path.splitext(entry)

        if is_dir and entry in exclude_dirs:
            continue
        if is_file:
            if entry in exclude_files:
                continue
            if ext in exclude_extensions:
                continue

        filtered_entries.append(entry)

    for index, entry in enumerate(filtered_entries):
        path = os.path.join(start_path, entry)
        is_last = index == len(filtered_entries) - 1
        connector = "└── " if is_last else "├── "

        print(prefix + connector + entry)

        if os.path.isdir(path):
            extension = "    " if is_last else "│   "
            print_tree(
                path,
                prefix + extension,
                exclude_dirs,
                exclude_files,
                exclude_extensions,
            )


if __name__ == "__main__":
    exclude_dirs, exclude_files, exclude_extensions = load_config()
    print_tree(
        "../",
        exclude_dirs=exclude_dirs,
        exclude_files=exclude_files,
        exclude_extensions=exclude_extensions,
    )
