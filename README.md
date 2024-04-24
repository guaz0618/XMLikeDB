# XMLikeDB
自訂設定檔，讀取XML資料工具。

過去工作專案設計並實作過的概念，以最簡單的處理功能呈現。
由Copilot協助快速製作，不包含防呆，null物件安全處理，提供求職展示用。

下載後可build Demo專案，並在產出目錄執行demo.bat。
同目錄下的demo.xml為來源資料，demo.js為讀取所需設定。

demo.js設定檔中，xcondition內容用來指定讀取資料的XPath，與該筆資料應取得欄位的XPath。
JSON內的資料會透過反序列化，由XMLikeDB.XDatabase依序yield return，減低讀取大型XML檔案時的資源耗用。
傳回資料XRow為單純的Dictionary<string,string>，提供後續的應用。

pipeline內容，用來對XRow的欄位資料作後處理。
需要先實作XMLikeDB.IPipeline，應用時可依照name欄位取得對應的執行邏輯，並將設定的參數採納入運作。

處理後的XRow資料亦可自行採用AutoMapper轉換為物件。
