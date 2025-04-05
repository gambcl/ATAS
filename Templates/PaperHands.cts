{
  "Value": {
    "$type": "OFT.Platform.Settings.Charting.ChartSettings, OFT.Platform",
    "ScaleByLowerValue": false,
    "ChartTraderIsEnabled": true,
    "SelectedAccount": "",
    "UseLocalVolumes": false,
    "TIF": 0,
    "TemplateType": "snapshot",
    "IsContinious": false,
    "PanelsIsHidden": false,
    "DrawingObjectses": [],
    "EndDate": "0001-01-01T00:00:00",
    "Template": {
      "TemplateType": "template",
      "ScaleByLowerValue": false,
      "ChartScale": 1,
      "Panels": [
        {
          "IsNew": true,
          "SerializedIndicators": [
            "{\r\n  \"Type\": \"ATAS.Indicators.Technical.BarTimer, ATAS.Indicators.Technical, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7\",\r\n  \"Settings\": \"{\\r\\n  \\\"TimeFormat\\\": \\\"auto\\\",\\r\\n  \\\"TimeMode\\\": \\\"timeToEndOfCandle\\\",\\r\\n  \\\"CustomTimeZone\\\": 0,\\r\\n  \\\"OffsetX\\\": 10,\\r\\n  \\\"OffsetY\\\": 15,\\r\\n  \\\"Size\\\": 15,\\r\\n  \\\"TimeLocation\\\": \\\"bottomRight\\\",\\r\\n  \\\"TextColor\\\": \\\"#DA008000\\\",\\r\\n  \\\"BackGroundColor\\\": \\\"#00FFFFFF\\\",\\r\\n  \\\"UseAlert\\\": false,\\r\\n  \\\"AlertFile\\\": \\\"alert1\\\",\\r\\n  \\\"AlertTextColor\\\": \\\"#FFFFFFFF\\\",\\r\\n  \\\"AlertBackgroundColor\\\": \\\"#FF000000\\\",\\r\\n  \\\"UseAlertBefore\\\": false,\\r\\n  \\\"AlertBeforeFile\\\": \\\"alert1\\\",\\r\\n  \\\"AlertBeforeSeconds\\\": 5,\\r\\n  \\\"ShowAlertArea\\\": false,\\r\\n  \\\"AreaBeforeColor\\\": \\\"255, 235, 59\\\",\\r\\n  \\\"TextBeforeColor\\\": \\\"255, 82, 82\\\",\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": true,\\r\\n  \\\"ShowDescription\\\": true,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.6959595\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.6960559Z\\\",\\r\\n  \\\"Name\\\": \\\"Bar Timer\\\",\\r\\n  \\\"Panel\\\": \\\"Chart\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"bars\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"BarTimerDefaultDataSeries\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Bar Timer\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": true\r\n}"
          ],
          "Height": 60,
          "Collapsed": false
        },
        {
          "IsNew": true,
          "SerializedIndicators": [
            "{\r\n  \"Type\": \"gambcl.ATAS.Indicators.HeikenAshi, gambcl-ATAS-Indicators, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null\",\r\n  \"Settings\": \"{\\r\\n  \\\"Days\\\": 1000,\\r\\n  \\\"ShowRealOpen\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FFFFFFFF\\\"\\r\\n  },\\r\\n  \\\"ShowRealClose\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FFE040FB\\\"\\r\\n  },\\r\\n  \\\"Width\\\": 2,\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": true,\\r\\n  \\\"ShowDescription\\\": true,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.7112702\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.7113726Z\\\",\\r\\n  \\\"Name\\\": \\\"HeikenAshi\\\",\\r\\n  \\\"Panel\\\": \\\"Chart\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"bars\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.PaintbarsDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"HideChart\\\": false,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"Bars\\\",\\r\\n  \\\"Type\\\": \\\"paintBars\\\",\\r\\n  \\\"Name\\\": \\\"Bars\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.CandleDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"UpCandleColor\\\": \\\"#FF3DC520\\\",\\r\\n  \\\"DownCandleColor\\\": \\\"#FFF55D5C\\\",\\r\\n  \\\"BorderColor\\\": \\\"#FF7D7D7D\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"Mode\\\": \\\"candles\\\",\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"Candles\\\",\\r\\n  \\\"Type\\\": \\\"candle\\\",\\r\\n  \\\"Name\\\": \\\"Heiken Ashi\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": true,\\r\\n  \\\"VisualType\\\": \\\"hash\\\",\\r\\n  \\\"Color\\\": \\\"#FFFFFFFF\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 2,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": false,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"RealOpen\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Real Open\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": true,\\r\\n  \\\"VisualType\\\": \\\"hash\\\",\\r\\n  \\\"Color\\\": \\\"#FFE040FB\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 2,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": false,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"RealClose\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Real Close\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": true\r\n}"
          ],
          "Height": 60,
          "Collapsed": false
        },
        {
          "IsNew": true,
          "SerializedIndicators": [
            "{\r\n  \"Type\": \"gambcl.ATAS.Indicators.PaperFeet, gambcl-ATAS-Indicators, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null\",\r\n  \"Settings\": \"{\\r\\n  \\\"EnterLongSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#804CAF50\\\"\\r\\n  },\\r\\n  \\\"EnterShortSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#80FF5252\\\"\\r\\n  },\\r\\n  \\\"EnterLongSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"LongEntry.wav\\\"\\r\\n  },\\r\\n  \\\"EnterShortSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"ShortEntry.wav\\\"\\r\\n  },\\r\\n  \\\"UseFractalEnergy\\\": true,\\r\\n  \\\"Alpha\\\": 0.2,\\r\\n  \\\"NFE\\\": 8,\\r\\n  \\\"GLength\\\": 13,\\r\\n  \\\"BetaDev\\\": 8,\\r\\n  \\\"OverboughtLevel\\\": 80.0,\\r\\n  \\\"OversoldLevel\\\": 20.0,\\r\\n  \\\"ShowOverboughtRegion\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#99FF5252\\\"\\r\\n  },\\r\\n  \\\"ShowOversoldRegion\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#994CAF50\\\"\\r\\n  },\\r\\n  \\\"EnterOverboughtAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"RSIOverbought.wav\\\"\\r\\n  },\\r\\n  \\\"ExitOverboughtAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"RSILeavingOverbought.wav\\\"\\r\\n  },\\r\\n  \\\"EnterOversoldAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"RSIOversold.wav\\\"\\r\\n  },\\r\\n  \\\"ExitOversoldAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"RSILeavingOversold.wav\\\"\\r\\n  },\\r\\n  \\\"AlertSoundsPath\\\": \\\"D:\\\\\\\\Trading\\\\\\\\ATAS Platform\\\\\\\\Sounds\\\",\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": true,\\r\\n  \\\"ShowDescription\\\": true,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.7515988\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.7516935Z\\\",\\r\\n  \\\"Name\\\": \\\"PaperFeet\\\",\\r\\n  \\\"Panel\\\": \\\"1\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"close\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"line\\\",\\r\\n  \\\"Color\\\": \\\"#FFFFFFFF\\\",\\r\\n  \\\"ValuesColor\\\": \\\"120, 123, 134\\\",\\r\\n  \\\"Width\\\": 2,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"LRSI\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Laguerre RSI\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"L0\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"L0\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"L1\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"L1\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"L2\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"L2\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"L3\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"L3\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"gO\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"gO\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"gH\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"gH\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"gL\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"gL\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": true,\\r\\n  \\\"Id\\\": \\\"gC\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"gC\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"Signals\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Signals\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": true\r\n}",
            "{\r\n  \"Type\": \"gambcl.ATAS.Indicators.VolumeDeltaDots, gambcl-ATAS-Indicators, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null\",\r\n  \"Settings\": \"{\\r\\n  \\\"DisplayLevel\\\": 44.0,\\r\\n  \\\"DisplayWidth\\\": 5,\\r\\n  \\\"BullishVolumeDeltaColor\\\": \\\"76, 175, 80\\\",\\r\\n  \\\"EqualVolumeDeltaColor\\\": \\\"255, 235, 59\\\",\\r\\n  \\\"BearishVolumeDeltaColor\\\": \\\"255, 82, 82\\\",\\r\\n  \\\"ShowLabel\\\": true,\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": false,\\r\\n  \\\"ShowDescription\\\": false,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.760137\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.760239Z\\\",\\r\\n  \\\"Name\\\": \\\"VolumeDeltaDots\\\",\\r\\n  \\\"Panel\\\": \\\"1\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"close\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"dots\\\",\\r\\n  \\\"Color\\\": \\\"#00FFFFFF\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 5,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": false,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"VolumeDeltaDots\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Volume Delta Dots\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": false\r\n}",
            "{\r\n  \"Type\": \"gambcl.ATAS.Indicators.MACloudDots, gambcl-ATAS-Indicators, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null\",\r\n  \"Settings\": \"{\\r\\n  \\\"ToggleToRecalculate\\\": true,\\r\\n  \\\"MAType\\\": \\\"ema\\\",\\r\\n  \\\"FastPeriod\\\": 9,\\r\\n  \\\"SlowPeriod\\\": 21,\\r\\n  \\\"DisplayLevel\\\": 56.0,\\r\\n  \\\"DisplayWidth\\\": 5,\\r\\n  \\\"BullishTrendColor\\\": \\\"76, 175, 80\\\",\\r\\n  \\\"BearishTrendColor\\\": \\\"255, 82, 82\\\",\\r\\n  \\\"ShowLabel\\\": true,\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": false,\\r\\n  \\\"ShowDescription\\\": false,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.7685882\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.768682Z\\\",\\r\\n  \\\"Name\\\": \\\"MACloudDots\\\",\\r\\n  \\\"Panel\\\": \\\"1\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"close\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"dots\\\",\\r\\n  \\\"Color\\\": \\\"#00FFFFFF\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 5,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": false,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"MACloudDots\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"EMA Cloud Dots\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": false\r\n}",
            "{\r\n  \"Type\": \"gambcl.ATAS.Indicators.ADXDots, gambcl-ATAS-Indicators, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null\",\r\n  \"Settings\": \"{\\r\\n  \\\"Period\\\": 14,\\r\\n  \\\"SmoothPeriod\\\": 14,\\r\\n  \\\"DisplayLevel\\\": 32.0,\\r\\n  \\\"DisplayWidth\\\": 5,\\r\\n  \\\"MediumTrendThreshold\\\": 15.0,\\r\\n  \\\"StrongTrendThreshold\\\": 23.0,\\r\\n  \\\"WeakTrendColor\\\": \\\"225, 190, 231\\\",\\r\\n  \\\"MediumTrendColor\\\": \\\"186, 104, 200\\\",\\r\\n  \\\"StrongTrendColor\\\": \\\"123, 31, 162\\\",\\r\\n  \\\"ShowLabel\\\": true,\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": false,\\r\\n  \\\"ShowDescription\\\": false,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.7798973\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.7799915Z\\\",\\r\\n  \\\"Name\\\": \\\"ADXDots\\\",\\r\\n  \\\"Panel\\\": \\\"1\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"bars\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": false,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"ADX\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"ADX\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"dots\\\",\\r\\n  \\\"Color\\\": \\\"#FFFFFFFF\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 5,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": false,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"ADXDots\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"ADX Dots\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": false\r\n}",
            "{\r\n  \"Type\": \"gambcl.ATAS.Indicators.HeikenAshiDots, gambcl-ATAS-Indicators, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null\",\r\n  \"Settings\": \"{\\r\\n  \\\"DisplayLevel\\\": 68.0,\\r\\n  \\\"DisplayWidth\\\": 5,\\r\\n  \\\"BullishTrendColor\\\": \\\"76, 175, 80\\\",\\r\\n  \\\"ChangingTrendColor\\\": \\\"253, 216, 53\\\",\\r\\n  \\\"BearishTrendColor\\\": \\\"242, 54, 69\\\",\\r\\n  \\\"ShowLabel\\\": true,\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": false,\\r\\n  \\\"ShowDescription\\\": false,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.7879915\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.7880896Z\\\",\\r\\n  \\\"Name\\\": \\\"HeikenAshiDots\\\",\\r\\n  \\\"Panel\\\": \\\"1\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"bars\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"dots\\\",\\r\\n  \\\"Color\\\": \\\"#FFFFFFFF\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 5,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": false,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"HeikenAshiDots\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Heiken Ashi Dots\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": false\r\n}"
          ],
          "Height": 249,
          "Collapsed": false
        },
        {
          "IsNew": true,
          "SerializedIndicators": [
            "{\r\n  \"Type\": \"gambcl.ATAS.Indicators.PaperArms, gambcl-ATAS-Indicators, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null\",\r\n  \"Settings\": \"{\\r\\n  \\\"ToggleToRecalculate\\\": false,\\r\\n  \\\"UseFractalEnergy\\\": true,\\r\\n  \\\"Alpha\\\": 0.2,\\r\\n  \\\"NFE\\\": 8,\\r\\n  \\\"GLength\\\": 13,\\r\\n  \\\"BetaDev\\\": 8,\\r\\n  \\\"OverboughtLevel\\\": 80.0,\\r\\n  \\\"OversoldLevel\\\": 20.0,\\r\\n  \\\"EnterLongSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FF4CAF50\\\"\\r\\n  },\\r\\n  \\\"EnterShortSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FFFF5252\\\"\\r\\n  },\\r\\n  \\\"ReenterLongSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FF4CAF50\\\"\\r\\n  },\\r\\n  \\\"ReenterShortSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FFFF5252\\\"\\r\\n  },\\r\\n  \\\"EntrySignalWidth\\\": 1,\\r\\n  \\\"EntrySignalOffset\\\": 4,\\r\\n  \\\"ExitLongSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FF4CAF50\\\"\\r\\n  },\\r\\n  \\\"ExitShortSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"#FFFF5252\\\"\\r\\n  },\\r\\n  \\\"ExitSignalWidth\\\": 4,\\r\\n  \\\"ExitSignalOffset\\\": 8,\\r\\n  \\\"EnterLongSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"LongEntry.wav\\\"\\r\\n  },\\r\\n  \\\"EnterShortSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"ShortEntry.wav\\\"\\r\\n  },\\r\\n  \\\"ReenterLongSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"LongEntry.wav\\\"\\r\\n  },\\r\\n  \\\"ReenterShortSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"ShortEntry.wav\\\"\\r\\n  },\\r\\n  \\\"ExitLongSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"ExitLong.wav\\\"\\r\\n  },\\r\\n  \\\"ExitShortSignalAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": true,\\r\\n    \\\"Value\\\": \\\"ExitShort.wav\\\"\\r\\n  },\\r\\n  \\\"MAType\\\": \\\"ema\\\",\\r\\n  \\\"FastPeriod\\\": 9,\\r\\n  \\\"SlowPeriod\\\": 21,\\r\\n  \\\"BuySignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"#FF4CAF50\\\"\\r\\n  },\\r\\n  \\\"SellSignalColor\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"#FFFF5252\\\"\\r\\n  },\\r\\n  \\\"SignalWidth\\\": 2,\\r\\n  \\\"SignalOffset\\\": 1,\\r\\n  \\\"BuyAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"BuySignal.wav\\\"\\r\\n  },\\r\\n  \\\"SellAlertFilter\\\": {\\r\\n    \\\"EnabledVisible\\\": true,\\r\\n    \\\"Enabled\\\": false,\\r\\n    \\\"Value\\\": \\\"SellSignal.wav\\\"\\r\\n  },\\r\\n  \\\"AlertSoundsPath\\\": \\\"D:\\\\\\\\Trading\\\\\\\\ATAS Platform\\\\\\\\Sounds\\\",\\r\\n  \\\"FullScreenMode\\\": false,\\r\\n  \\\"DenyToChangePanel\\\": true,\\r\\n  \\\"ShowDescription\\\": true,\\r\\n  \\\"MarketTime\\\": \\\"2025-04-05T14:19:38.8263564\\\",\\r\\n  \\\"UtcTime\\\": \\\"2025-04-05T14:19:38.8264597Z\\\",\\r\\n  \\\"Name\\\": \\\"PaperArms\\\",\\r\\n  \\\"Panel\\\": \\\"Chart\\\",\\r\\n  \\\"IsVerticalIndicator\\\": false,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"Locked\\\": false,\\r\\n  \\\"AllowedInteraction\\\": true\\r\\n}\",\r\n  \"SourceType\": \"close\",\r\n  \"SourceSeriesId\": 0,\r\n  \"DataSeries\": [\r\n    {\r\n      \"Type\": \"ATAS.Indicators.RangeDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"RangeColor\\\": \\\"#664CAF50\\\",\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"BullishCloud\\\",\\r\\n  \\\"Type\\\": \\\"band\\\",\\r\\n  \\\"Name\\\": \\\"Bullish Cloud\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.RangeDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"RangeColor\\\": \\\"#66FF5252\\\",\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"Visible\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"BearishCloud\\\",\\r\\n  \\\"Type\\\": \\\"band\\\",\\r\\n  \\\"Name\\\": \\\"Bearish Cloud\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FF4CAF50\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"FastMA\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"9 EMA\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"hide\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": false,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"SlowMA\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"21 EMA\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"upArrow\\\",\\r\\n  \\\"Color\\\": \\\"#FF4CAF50\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 2,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"BuySignal\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Buy Signal\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"downArrow\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 2,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": true,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"SellSignal\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Sell Signal\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"upArrow\\\",\\r\\n  \\\"Color\\\": \\\"#FF4CAF50\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"EnterLong\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"EnterLong\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"downArrow\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"EnterShort\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"EnterShort\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"upArrow\\\",\\r\\n  \\\"Color\\\": \\\"#FF4CAF50\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"ReEnterLong\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"ReEnterLong\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"downArrow\\\",\\r\\n  \\\"Color\\\": \\\"#FFFF5252\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 1,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"ReEnterShort\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"ReEnterShort\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    },\r\n    {\r\n      \"Type\": \"ATAS.Indicators.ValueDataSeries, ATAS.Indicators, Version=7.0.7.328, Culture=neutral, PublicKeyToken=null\",\r\n      \"Settings\": \"{\\r\\n  \\\"Digits\\\": 4,\\r\\n  \\\"StringFormat\\\": \\\"{0:0.####}\\\",\\r\\n  \\\"ShowOnlyNonZeroLabels\\\": false,\\r\\n  \\\"VisualType\\\": \\\"block\\\",\\r\\n  \\\"Color\\\": \\\"#FFFFFFFF\\\",\\r\\n  \\\"ValuesColor\\\": \\\"White\\\",\\r\\n  \\\"Width\\\": 4,\\r\\n  \\\"LineDashStyle\\\": \\\"solid\\\",\\r\\n  \\\"ShowZeroValue\\\": true,\\r\\n  \\\"ShowCurrentValue\\\": false,\\r\\n  \\\"ScaleIt\\\": true,\\r\\n  \\\"DrawAbovePrice\\\": true,\\r\\n  \\\"IgnoredByAlerts\\\": false,\\r\\n  \\\"Id\\\": \\\"Exit\\\",\\r\\n  \\\"Type\\\": \\\"value\\\",\\r\\n  \\\"Name\\\": \\\"Exit\\\",\\r\\n  \\\"DescriptionKey\\\": \\\"VisualizationDescription\\\"\\r\\n}\"\r\n    }\r\n  ],\r\n  \"LineSeries\": [],\r\n  \"ShowDescription\": true\r\n}"
          ],
          "Height": 60,
          "Collapsed": false
        }
      ],
      "Indicators": [],
      "clusterSettings": {
        "Caption": "Cluster Settings",
        "Volumes": "#FF2962FF",
        "Bid": "#FFF71427",
        "Ask": "#FF2962FF",
        "ClusterBorderWidth": 1,
        "Foreground": "#FFABAEB8",
        "AutoSize": true,
        "FontSize": 9.0,
        "CutLongText": true,
        "MinimumClusterWidthToShowText": 40,
        "ValueAreaColor": "#64C8D8FF",
        "ShowValueArea": false,
        "ImbalanceBid": "#FFFFFFFF",
        "ImbalanceAsk": "#FFFFFFFF",
        "MinimumImbalanceDifference": 0,
        "IgnoreZeroValues": false,
        "ImbalanceVolumeFilter": 0,
        "ImbalanceRate": 150,
        "ShowDirectionMarker": true,
        "DirectionMakerWidth": 0,
        "ClusterBorderPen": {
          "LineDashStyle": "solid",
          "Width": 2,
          "Color": "#FF2A2E39"
        },
        "BorderColorByDirection": false,
        "SecondClusters": {
          "Caption": "",
          "Enabled": false,
          "ClustersContentModeFilter": {
            "EnumType": "OFT.Controls.Chart.enums.ClustersContentModes, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
            "Value": "volume",
            "Enabled": false,
            "EnabledVisible": false
          },
          "ClustersContentMode": "volume",
          "ClustersModeFilter": {
            "EnumType": "OFT.Controls.Chart.enums.ClustersVisualModes, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
            "Value": "fullRow",
            "Enabled": false,
            "EnabledVisible": false
          },
          "ClustersMode": "fullRow",
          "UseBorderOfEachPriceLevelFilter": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": false
          },
          "UseBorderOfEachPriceLevel": false,
          "ColorSchemeFilter": {
            "EnumType": "OFT.Controls.Chart.enums.ClustersColorSchemes, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
            "Value": "volumeProportion",
            "Enabled": false,
            "EnabledVisible": false
          },
          "ColorScheme": "volumeProportion",
          "ClusterBGFilter": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": "#00FFFFFF"
          },
          "ClusterBG": "#00FFFFFF",
          "VolumeColor": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": "#FF2962FF"
          },
          "BidColor": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": "#FFF71427"
          },
          "AskColor": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": "#FF2962FF"
          },
          "HeatmapType": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": 0
          },
          "UpperCutOff": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": 20
          },
          "Contrast": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": 0
          },
          "MaxVolTypeFilter": {
            "EnumType": "Advanced_Time_And_Sales.ClusterSettings+MaxVolSelectionType, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
            "Value": "volume",
            "Enabled": false,
            "EnabledVisible": false
          },
          "MaxVolType": "volume",
          "MaxVolColorFilter": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": "#00000000"
          },
          "MaxVolColor": "#00000000",
          "MaxVolSelectionWidthFilter": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": 1
          },
          "MaxVolSelectionWidth": 1,
          "MaxVolTextColorFilter": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": "#FFD1D4DC"
          },
          "MaxVolTextColor": "#FFD1D4DC",
          "MaxLevelBoldFilter": {
            "EnabledVisible": false,
            "Enabled": false,
            "Value": true
          },
          "MaxLevelBold": true
        },
        "BorderType": "body",
        "BorderColorByDirectionFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": false
        },
        "ClusterBorderPenFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": {
            "Color": "#FF2A2E39",
            "LineDashStyle": 0,
            "Width": 2
          }
        },
        "ShowDirectionMarkerFilter": {
          "EnabledVisible": true,
          "Enabled": true,
          "Value": 0
        },
        "Showtext": true,
        "ForegroundFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": "#FFABAEB8"
        },
        "AutoSizeFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": true
        },
        "FontSizeFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 9.0
        },
        "Divider": 1.0,
        "CutLongTextFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": true
        },
        "MinimumClusterWidthToShowTextFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": 40
        },
        "ValueAreaColorFilter": {
          "EnabledVisible": true,
          "Enabled": false,
          "Value": "#64C8D8FF"
        },
        "ProportionalMode": "visibleRegion",
        "ProportionalHistogram": true,
        "ProportionByAllBars": false,
        "GradientRate": 100,
        "CustomProportionValue": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 0.0
        },
        "CustomproportionVolume": 0.0,
        "UpperCutOffGradient": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 0
        },
        "EnableBidAskImbalance": false,
        "ImbalanceBidFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": "#FFFFFFFF"
        },
        "ImbalanceAskFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": "#FFFFFFFF"
        },
        "ImbalanceRateFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 150
        },
        "ImbalanceVolumeFilterInt": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 0
        },
        "MinimumImbalanceDifferenceFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 0
        },
        "IgnoreZeroValuesFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": false
        },
        "BoldFontForImbalances": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": false
        },
        "CustomRowHeight": {
          "EnabledVisible": true,
          "Enabled": false,
          "Value": 16
        },
        "Filters": [],
        "ClustersContentModeFilter": {
          "EnumType": "OFT.Controls.Chart.enums.ClustersContentModes, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
          "Value": "bidXAsk",
          "Enabled": true,
          "EnabledVisible": false
        },
        "ClustersContentMode": "bidXAsk",
        "ClustersModeFilter": {
          "EnumType": "OFT.Controls.Chart.enums.ClustersVisualModes, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
          "Value": "volumeHistogram",
          "Enabled": true,
          "EnabledVisible": false
        },
        "ClustersMode": "volumeHistogram",
        "UseBorderOfEachPriceLevelFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": false
        },
        "UseBorderOfEachPriceLevel": false,
        "ColorSchemeFilter": {
          "EnumType": "OFT.Controls.Chart.enums.ClustersColorSchemes, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
          "Value": "volumeBasedBidAsk",
          "Enabled": true,
          "EnabledVisible": false
        },
        "ColorScheme": "volumeBasedBidAsk",
        "ClusterBGFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": "#00FFFFFF"
        },
        "ClusterBG": "#00FFFFFF",
        "VolumeColor": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": "#FF2962FF"
        },
        "BidColor": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": "#FFF71427"
        },
        "AskColor": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": "#FF2962FF"
        },
        "HeatmapType": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 10
        },
        "UpperCutOff": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 50
        },
        "Contrast": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": 11
        },
        "MaxVolTypeFilter": {
          "EnumType": "Advanced_Time_And_Sales.ClusterSettings+MaxVolSelectionType, OFT.Platform.Core, Version=7.0.7.328, Culture=neutral, PublicKeyToken=330427d8594115c7",
          "Value": "volume",
          "Enabled": true,
          "EnabledVisible": false
        },
        "MaxVolType": "volume",
        "MaxVolColorFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": "#00FFFFFF"
        },
        "MaxVolColor": "#00FFFFFF",
        "MaxVolSelectionWidthFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": 1
        },
        "MaxVolSelectionWidth": 1,
        "MaxVolTextColorFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": "#FFD1D4DC"
        },
        "MaxVolTextColor": "#FFD1D4DC",
        "MaxLevelBoldFilter": {
          "EnabledVisible": false,
          "Enabled": true,
          "Value": true
        },
        "MaxLevelBold": true
      },
      "colorsettings": {
        "BuyCandlePricePen": {
          "Color": "61, 197, 32",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "SellCandlePricePen": {
          "Color": "245, 93, 92",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "BuyBarPricePen": {
          "Color": "8, 153, 129",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "SellBarPricePen": {
          "Color": "242, 56, 90",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "DojiBarPricePen": {
          "Color": "125, 125, 125",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "LineChartPricePen": {
          "Color": "41, 98, 255",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "MountainChartPricePen": {
          "Color": "71, 107, 150",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "SolidCurrentPricePen": {
          "Color": "54, 58, 69",
          "DashStyle": "dash",
          "Width": 1.0
        },
        "Caption": "Chart Color Settings",
        "BackgroundBrushSettings": {
          "UseEndColor": false,
          "StartColor": "#FF000000",
          "EndColor": "#FFADD8E6"
        },
        "BackGround": "#FF000000",
        "OhlcColor": {
          "EnabledVisible": true,
          "Enabled": true,
          "Value": "#FFABAEB8"
        },
        "StateColor": "#FFABAEB8",
        "TextHistogramColor": "#FFB2B5BE",
        "LabelsBackgroundColor": "#00000000",
        "IndicatorsSeparator": {
          "LineDashStyle": "solid",
          "Width": 1,
          "Color": "#FF434651"
        },
        "CurrentPriceColor": {
          "EnabledVisible": true,
          "Enabled": false,
          "Value": "#FF363A45"
        },
        "PriceLinePen": {
          "LineDashStyle": "dash",
          "Width": 1,
          "Color": "#FFEF5350"
        },
        "PriceLineDashStyle": "dash",
        "PriceLineWidth": 1,
        "ExtendPriceLine": true,
        "CrosshairPen": {
          "LineDashStyle": "dash",
          "Width": 1,
          "Color": "#FF9598A1"
        },
        "AVersion": 1,
        "AxisCurrentBackColor": "#FF363A45",
        "AxisCurrentForeColor": "#FFF1F1F1",
        "GridPen": {
          "LineDashStyle": "solid",
          "Width": 1,
          "Color": "#FF21252F"
        },
        "ShowVHorizontalGrid": false,
        "CustomGridStep": 0,
        "ShowVericalGrid": false,
        "CustomVertGridStep": 0,
        "NewSessionPen": {
          "LineDashStyle": "dash",
          "Width": 1,
          "Color": "#FF4985E7"
        },
        "AxisColorFilter": {
          "EnabledVisible": true,
          "Enabled": false,
          "Value": "#FF151B26"
        },
        "AxisColor": "#FF151B26",
        "AxisTextColor": "#FFABAEB8",
        "FontSizeDecimal": 10.0,
        "TimeFormat": "auto",
        "HidePriceAxis": false,
        "DrawAxisBorders": false,
        "BuyColor": "#FF3DC520",
        "SellColor": "#FFF55D5C",
        "DrawCandleBorder": true,
        "CandleBorderColorAsBody": true,
        "CellBorderColor": "#FF7D7D7D",
        "CandleBorderWidth": 1,
        "BarsWidth": 1,
        "DojiBarColor": "#FF7D7D7D",
        "DownBarColor": "#FFF2385A",
        "UpBarColor": "#FF089981",
        "ShowOpenOfBar": true,
        "ShowCloseOfBar": true,
        "ChartLinePen": {
          "LineDashStyle": "solid",
          "Width": 1,
          "Color": "#FF2962FF"
        },
        "MountainLinePen": {
          "LineDashStyle": "solid",
          "Width": 1,
          "Color": "#FF2962FF"
        },
        "MountainBrushSettings": {
          "UseEndColor": true,
          "StartColor": "#B62962FF",
          "EndColor": "#062962FF"
        },
        "UseSessionTime": false,
        "SessionStartFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": "00:00:00"
        },
        "SessionStart": "00:00:00",
        "SessionEndFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": "23:59:59"
        },
        "SessionEnd": "23:59:59",
        "PriceBorder": false,
        "ShowIndicatorsValuesOnMouseOver": true,
        "AutoTransFormCandles": false,
        "CandleSizeTotransformToClusters": 20,
        "HideClustersPanel": false,
        "AutoTransformHorizontalLines": false,
        "AutoTransformVerticalLines": false,
        "PriceOffset": 200,
        "ChartOffset": 30,
        "UseSmoothing": true,
        "MouseWheelBehavior": "zoom",
        "LeaveRulerOnMouseRelease": false,
        "ShowIndicatorsList": true,
        "MinimizeValues": true,
        "DigitsAfterComma": 0,
        "VolumesInUSDTFilter": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": false
        },
        "VolumesInUSD": false,
        "KeepSelectedObjects": false,
        "ObjectsSelectionDrawingColor": "30, 83, 228",
        "ObjectsSelectionColor": "#FF1E53E4",
        "Sensitivity": 0,
        "UseOptimizationMode": false,
        "UseCustomUpdateIntervals": false,
        "CustomFPS": {
          "EnabledVisible": false,
          "Enabled": false,
          "Value": {
            "Start": 10,
            "End": 50
          }
        },
        "IsChartInstrumentCrypto": false,
        "IndicatorsListIsCollapsed": false,
        "VolumeValuesFormat": "{0:0.}",
        "RedrawInterval": 100,
        "NewSessionLineColor": "#FF4985E7",
        "Сl_crosshair": "#FF9598A1",
        "GridColor": "#FF21252F",
        "HistogramLinesColor": "#C8ADD8E6",
        "HistogramColor": "#FF808080",
        "ShowCumulativeValues": true,
        "BidColor": "#FFE84548",
        "AskColor": "#FF49D149",
        "ValueAreaColor": "#FFC8D8FF",
        "PocColor": "#FFC8D8FF",
        "HistogramTextColor": "#FF35212E",
        "ExtendPoc": false,
        "ExtendValueArea": false
      },
      "histogramInterval": "contract",
      "typeHistogram": "bidAsk",
      "ShowHistogram": false,
      "ShowingDigital": false,
      "UseOpacility": false,
      "ShowTxtMouse": true,
      "VisibleCrossHair": true,
      "ShowValueArea": true,
      "ShowPoc": true,
      "AlwaysOnTop": false,
      "BarsType": "candles",
      "ClusterWidth": 12.240445123238248436615359469,
      "TypeCluster": "volume",
      "PaintingMode": "drawCrossHair",
      "TradingSettings": {
        "PnLMode": "money",
        "Caption": "",
        "ShowText": true,
        "OneClickMode": true,
        "TradingMode": "autoDetection",
        "StopMode": "stop",
        "Slippage": 5,
        "ShowTrades": "visible",
        "Size": 6,
        "TradesColor": "#FF2962FF",
        "TradesSellColor": "#FF2962FF",
        "ShowOrders": "visible",
        "OrdersOffset": 115,
        "BuyOrdersColors": "#FF089981",
        "SellOrdersColor": "#FFF2385A",
        "LimitColors": "#FF089981",
        "StopColor": "#FFF2385A",
        "OrderstextColor": "#FFD1D4DC",
        "ShowPosition": "visible",
        "PositionOffset": 115,
        "PositionTextColors": "#FFF1F1F1",
        "PositionBackGround": "#FF151B26",
        "PositionPositive": "#FF089981",
        "PositionNegative": "#FFF2385A",
        "SkipValidateStrategy": false
      },
      "ClusterVisualizationType": "bidAskLadder",
      "Version": 1,
      "ChangeHeightmanualy": true,
      "RowHeight": 0.13117871894753114,
      "UseAutoScale": true,
      "LayoutString": "<XtraSerializer version=\"1.0\" application=\"\">\r\n  <property name=\"#LayoutVersion\">1.4</property>\r\n  <property name=\"$BarManager\" iskey=\"true\" value=\"BarManager\">\r\n    <property name=\"RuntimeCustomizations\" iskey=\"true\" value=\"9\">\r\n      <property name=\"Item1\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">Visible</property>\r\n        <property name=\"NewValue\" type=\"System.Boolean\">false</property>\r\n        <property name=\"OldValue\" type=\"System.Boolean\">true</property>\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">ToolBar</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">-807631421</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item2\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">DockInfo.ContainerName</property>\r\n        <property name=\"NewValue\" type=\"System.String\" />\r\n        <property name=\"OldValue\" isnull=\"true\" />\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">ToolBar</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">1739292312</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item3\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">DockInfo.ContainerName</property>\r\n        <property name=\"NewValue\" type=\"System.String\" />\r\n        <property name=\"OldValue\" isnull=\"true\" />\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">DrawingObjectsToolbar</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">1739292328</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item4\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">DockInfo.ContainerName</property>\r\n        <property name=\"NewValue\" type=\"System.String\" />\r\n        <property name=\"OldValue\" isnull=\"true\" />\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">ClusterBar</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">1739292328</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item5\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">Visible</property>\r\n        <property name=\"NewValue\" type=\"System.Boolean\">false</property>\r\n        <property name=\"OldValue\" type=\"System.Boolean\">true</property>\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">ToolBarRight</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">-1435440406</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item6\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">DockInfo.ContainerName</property>\r\n        <property name=\"NewValue\" type=\"System.String\" />\r\n        <property name=\"OldValue\" isnull=\"true\" />\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">ToolBarRight</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">278993734</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item7\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">DockInfo.ContainerName</property>\r\n        <property name=\"NewValue\" type=\"System.String\" />\r\n        <property name=\"OldValue\" type=\"System.String\" />\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">ToolBar</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">278993734</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item8\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">DockInfo.ContainerName</property>\r\n        <property name=\"NewValue\" type=\"System.String\" />\r\n        <property name=\"OldValue\" type=\"System.String\" />\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">DrawingObjectsToolbar</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">278993734</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n      <property name=\"Item9\" isnull=\"true\" iskey=\"true\">\r\n        <property name=\"PropertyName\">DockInfo.ContainerName</property>\r\n        <property name=\"NewValue\" type=\"System.String\" />\r\n        <property name=\"OldValue\" type=\"System.String\" />\r\n        <property name=\"ActOnHost\">false</property>\r\n        <property name=\"TargetName\">ClusterBar</property>\r\n        <property name=\"Overwrite\">true</property>\r\n        <property name=\"Timestamp\">278993734</property>\r\n        <property name=\"CustomizationType\">DevExpress.Xpf.Bars.RuntimePropertyCustomization</property>\r\n        <property name=\"AffectedTargets\" iskey=\"true\" value=\"0\" />\r\n      </property>\r\n    </property>\r\n  </property>\r\n  <property name=\"$BarManager$ChartLayoutControl\" iskey=\"true\" value=\"BarManager$ChartLayoutControl\">\r\n    <property name=\"CollapsableContentWidth\">237</property>\r\n  </property>\r\n</XtraSerializer>",
      "Minimum": 16933.568889971790700315771487,
      "Maximum": 18118.974581135743060328151263
    },
    "TimeFrame": {
      "Period": "timeFrame",
      "PeriodParameters": {
        "$type": "OFT.Controls.Chart.MinuteTimeFrame, OFT.Controls",
        "TimeFrame": "m5",
        "CustomTimeFrame": 1,
        "Label": "@value",
        "DefaultDaysToLoad": 4,
        "VisualName": "M5"
      },
      "CustomDaysCount": 1,
      "CustomEndDate": "2025-03-13T21:15:00",
      "CustomStartDate": "2023-05-17T00:00:00",
      "LoadCustomDateSetting": false,
      "CustomDateSetting": "daysCount",
      "IsHistorical": false
    },
    "Canvas": {
      "Elements": []
    },
    "LinkedPanels": [],
    "Width": 12.240445123238248436615359469,
    "StrategySettings": [],
    "TraderSettings": {
      "SelectedTIF": "goodTillCancel",
      "Volume": 3.0,
      "ApplyToAllWindow": false,
      "SelectedCurrency": "Lots",
      "IsPercentMode": false,
      "MarketOrderFlags": {},
      "LimitOrderFlags": {},
      "ConditionalMarketOrderFlags": {},
      "ConditionalLimitOrderFlags": {}
    },
    "IsVisibleDrawingObjectsBar": true,
    "TradingSession": {
      "Id": 7
    }
  },
  "IsSystem": false
}