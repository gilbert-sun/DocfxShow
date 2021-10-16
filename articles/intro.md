# WPF 與 MongoDB 目錄結構說明 !

*. WPF 首頁

![img_21.png](../images/img_21.png)

*. Directory: 目錄結構如下

![img6.png](../images/img6.png)

*. d/f  目錄/檔名 :: 只對WPF有使用到mongoDB的目錄做解釋

----  ------- ----
d-----Models

    --MongoDB Model對應MVC裡面的Ｍ，有兩部份，一是抓取紀錄(MongoPickDBmodel.cs)，二是錯誤紀錄(MongologDBmodel.cs)

![img_3.png](../images/img_3.png)

d-----Services

    --MongoDB Service對應MVC裡面的C(controller)，有兩部份，一是抓取紀錄(MongoPickMongoServices.cs)，二是錯誤紀錄(MongoLogMongoServices.cs)

![img_2.png](../images/img_2.png)

d-----UserControls

    --對應WPF UI的細部元件之使用者控制邏輯撰寫

![img_18.png](../images/img_18.png)

d-----ViewModels

    --對應WPF UI的頁面之使用者控制邏輯撰寫

![img_20.png](../images/img_20.png)

d-----Views

    --對應WPF UI的頁面之Layout之設計與對應binding ViewModel跟UserControl的Method邏輯撰寫

![img_19.png](../images/img_19.png)

d-----Selectors

d-----Dependencies

d-----Properities

d-----Converters

d-----Core

d-----Images

d-----Languages

d-----Libraries

d-----Resources

d-----Styles

-f----App.config

-f----App.xaml

-f----App.xaml.cs

-f----MainWindows.xaml


