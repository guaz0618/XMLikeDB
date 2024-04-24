{
    "xcondition": {
        "xrow": "//table[@class='contacts']/tr",
        "xcells": [
            { "xpath": "td[@title='first-name']", "key": "fname" },
            { "xpath": "td[@title='last-name']", "key": "lname" },
            { "xpath": "td[@title='phone']", "key": "Phone"},
            { "xpath": "td[@title='email']", "key": "Email"}
        ]
    },
    "pipeline": [
        { "name": "concat", "from": ["fname", "lname"], "to": "Name", "separator": " " },
        { "name": "regex-replace", "from": "Phone", "to": "Phone", "pattern": "[^0-9]", "replacement": "" }
    ]
}