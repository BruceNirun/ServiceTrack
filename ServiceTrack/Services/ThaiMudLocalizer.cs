using Microsoft.Extensions.Localization;
using MudBlazor;

namespace ServiceTrack.Services;

public class ThaiMudLocalizer : MudLocalizer
{
    private Dictionary<string, string> _localization;

    public ThaiMudLocalizer()
    {
        _localization = new()
        {
            // === ปุ่มพื้นฐาน ===
            { "MudDatePicker.Ok", "ตกลง" },
            { "MudDatePicker.Cancel", "ยกเลิก" },
            { "MudDatePicker.Clear", "ล้างค่า" },
            { "MudDatePicker.Today", "วันนี้" },

            // === วันในสัปดาห์ (แบบย่อ) ===
            { "MudDatePicker.Sunday", "อา" },
            { "MudDatePicker.Monday", "จ" },
            { "MudDatePicker.Tuesday", "อ" },
            { "MudDatePicker.Wednesday", "พ" },
            { "MudDatePicker.Thursday", "พฤ" },
            { "MudDatePicker.Friday", "ศ" },
            { "MudDatePicker.Saturday", "ส" },

            // === ชื่อเดือน ===
            { "MudDatePicker.January", "มกราคม" },
            { "MudDatePicker.February", "กุมภาพันธ์" },
            { "MudDatePicker.March", "มีนาคม" },
            { "MudDatePicker.April", "เมษายน" },
            { "MudDatePicker.May", "พฤษภาคม" },
            { "MudDatePicker.June", "มิถุนายน" },
            { "MudDatePicker.July", "กรกฎาคม" },
            { "MudDatePicker.August", "สิงหาคม" },
            { "MudDatePicker.September", "กันยายน" },
            { "MudDatePicker.October", "ตุลาคม" },
            { "MudDatePicker.November", "พฤศจิกายน" },
            { "MudDatePicker.December", "ธันวาคม" }
        };
    }

    public override LocalizedString this[string key]
    {
        get
        {
            if (_localization.TryGetValue(key, out var res))
            {
                return new LocalizedString(key, res);
            }
            return base[key];
        }
    }
}