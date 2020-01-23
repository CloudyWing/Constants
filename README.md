# Constants

常數物件，將常數物件重複的行為整理成Constant\<T\>。

## Supported Frameworks
* .NET Standard 2.1
* .NET Standard 2.0
* .NET Framework 4.5

## Examples
```
/// int 可替換任何implement IConvertible的type
[Serializable]
public sealed class WeekDay : Constant<int> {
    private readonly static IList<WeekDay> items;
    public static readonly WeekDay Sunday;
    public static readonly WeekDay Monday;
    public static readonly WeekDay Tuesday;
    public static readonly WeekDay Wednesday;
    public static readonly WeekDay Thursday;
    public static readonly WeekDay Friday;
    public static readonly WeekDay Saturday;

    // 建立一個static constructor來初始化各個物件
    static WeekDay() {
        // 前兩個參數固定為Value和Text，後面可以自行擴充
        Sunday = new WeekDay(0, "星期日", nameof(Sunday));
        Monday = new WeekDay(1, "星期一", nameof(Monday));
        Tuesday = new WeekDay(2, "星期二", nameof(Tuesday));
        Wednesday = new WeekDay(3, "星期三", nameof(Wednesday));
        Thursday = new WeekDay(4, "星期四", nameof(Thursday));
        Friday = new WeekDay(5, "星期五", nameof(Friday));
        Saturday = new WeekDay(6, "星期六", nameof(Saturday));

        items = new List<WeekDay>() {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        };
    }

    // constructor設定成private
    private WeekDay(int value, string text, string name) : base(value, text) {
        Name = name;
    }

    // 定義int強制轉換成WeekDay的operator
    public static explicit operator WeekDay(int value) {
        return items.Where(x => x.Value == value).SingleOrDefault() ??
            throw new InvalidCastException(); // 視情況決定要throw InvalidCastException還是返回初始值
    }

    // 額外擴充的Property
    public string Name { get; }

    // 不要直接回傳IList<WeekDay>，避免被人異動裡面內容
    public static IReadOnlyList<WeekDay> GetItems() => new ReadOnlyCollection<WeekDay>(items);
}
```

完整範例請參考
[Constants.Examples](https://github.com/CloudyWing/Constants/tree/master/Constants.Examples)

## License
This project is MIT [licensed](https://github.com/CloudyWing/Constants/blob/master/LICENSE.md).