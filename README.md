# XMLikeDB
工具介紹：
這是一款可透過自訂設定檔，藉由指定之XPath路徑，讀取XML內含資料的工具。此工具旨在處理業務需求的XML來源資料，簡化資料解析工作，即使非程式開發專業人員也能通過編輯設定檔進行處理，從而減少程式變更後的維護需求。

工具開發背景：
在過去的工作專案中，我曾設計並實作過類似的概念。這次的工具是由Copilot協助快速製作的簡化版本，不包含防呆和null物件安全處理，僅供求職展示使用。工具的主要目的是處理由第三方工具產生的XML來源資料，這些資料會隨著版本的改變而變更其結構。

使用說明：
下載並執行：
下載後可build Demo專案，並在產出目錄中執行demo.bat。
在同目錄下，有demo.xml作為來源資料，demo.js為讀取所需設定。

設定檔說明：
demo.js設定檔中，xcondition內容用來指定讀取資料的XPath，與該筆資料應取得欄位的XPath。JSON內的資料會透過反序列化，由XMLikeDB.XDatabase依序yield return，從而減少讀取大型XML檔案時的資源耗用。傳回的資料XRow為單純的Dictionary<string, string>，便於後續應用。

資料後處理：
pipeline內容用來對XRow的欄位資料作後處理。需要先實作XMLikeDB.IPipeline，應用時可依照name欄位取得對應的執行邏輯，並將設定的參數納入運作。
