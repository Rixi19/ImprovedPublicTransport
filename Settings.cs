﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ImprovedPublicTransport2.OptionsFramework.Attibutes;

namespace ImprovedPublicTransport2
{
    [Options("ImprovedPublicTransport2", "ImprovedPublicTransportSettings")]
    public class Settings
    {
        private const string SETTINGS_COMMON = "SETTINGS";
        private const string SETTINGS_UI = "SETTINGS_UI";
        private const string SETTINGS_BUDGET = "SETTINGS_ENABLE_BUDGET_CONTROL";
        private const string SETTINGS_UNBUNCHING = "UNBUNCHING_ENABLED";

        [Textfield("SETTINGS_SPEED", SETTINGS_COMMON)]
        public string SpeedString { get; set; } = "km/h";

        [Description("SETTINGS_AUTOSHOW_LINE_INFO_TOOLTIP")]
        [Checkbox("SETTINGS_AUTOSHOW_LINE_INFO", SETTINGS_COMMON)]
        public bool ShowLineInfo { get; set; } = true;

        [BudgetDescription]
        [Checkbox(SETTINGS_BUDGET, SETTINGS_BUDGET, nameof(SettingsActions), nameof(SettingsActions.OnBudgetCheckChanged))]  //TODO(earalov): add new locale?
        public bool BudgetControl { get; set; } = true;

        [BudgetDescription]
        [Button("SETTINGS_UPDATE", SETTINGS_BUDGET, nameof(SettingsActions), nameof(SettingsActions.OnUpdateButtonClick))]
        [XmlIgnore]
        public object BudgetControlUpdateButton { get; } = null;

        public bool CompatibilityMode { get; set; } //deprecated

        public int SpawnTimeInterval { get; set; } = 10;

        public int DefaultVehicleCount { get; set; } = 0;

        [AggressionDescription]
        [Slider("SETTINGS_UNBUNCHING_AGGRESSION", 0.0f, 52.0f, 1.0f, SETTINGS_UNBUNCHING)]
        public byte IntervalAggressionFactor { get; set; } = 52; //TODO(earalov): convert into max seconds at stop

        public bool Unbunching { get; } = true; //deprecated

        public int StatisticWeeks { get; set; } = 10;

        [DropDown("SETTINGS_VEHICLE_EDITOR_POSITION", nameof(VehicleEditorPositions), SETTINGS_UI)]
        public int VehicleEditorPosition { get; set; } = (int) VehicleEditorPositions.Bottom;

        [Checkbox("SETTINGS_VEHICLE_EDITOR_HIDE", SETTINGS_UI)]
        public bool HideVehicleEditor { get; set; }

        [AttributeUsage(AttributeTargets.All)]
        public class BudgetDescriptionAttribute : DescriptionAttribute
        {
            public BudgetDescriptionAttribute() : 
                base(Localization.Get("SETTINGS_BUDGET_CONTROL_TOOLTIP") + System.Environment.NewLine + Localization.Get("EXPLANATION_BUDGET_CONTROL"))
            {
                
            }
        }

        [AttributeUsage(AttributeTargets.All)]
        public class AggressionDescriptionAttribute : DescriptionAttribute
        {
            public AggressionDescriptionAttribute() :
                base(Localization.Get("SETTINGS_UNBUNCHING_AGGRESSION_TOOLTIP") + System.Environment.NewLine + Localization.Get("EXPLANATION_UNBUNCHING"))
            {

            }
        }
    }

}