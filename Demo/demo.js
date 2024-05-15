{
    "xcondition": {
        "xrow": "//table[@class='contacts']/tr",    /* 指定欲擷取資料的XPath */
        "xcells": [   /* 指定上述xrow擷取資料，應取得欄位的XPath。描述的XPath會將xrow節點視為根節點 */
            { "xpath": "td[@title='first-name']", "key": "fname" }, /* key用來指定欄位名稱 */
            { "xpath": "td[@title='last-name']", "key": "lname" },
            { "xpath": "td[@title='phone']", "key": "Phone"},
            { "xpath": "td[@title='email']", "key": "Email"}
        ]
    },
    "pipeline": [   /* 指定資料後處理的流程 */
        { "name": "concat", "from": ["fname", "lname"], "to": "Name", "separator": " " }, /* 將fname與lname欄位合併為Name欄位 */
        { "name": "regex-replace", "from": "Phone", "to": "Phone", "pattern": "[^0-9]", "replacement": "" } /* 將Phone欄位中的非數字字元移除 */
    ]
}