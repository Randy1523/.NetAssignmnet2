using System.ComponentModel;

namespace UsageData;

//BindingList that supports click-to-sort on DataGridView column headers.
public sealed class SortableBindingList<T> : BindingList<T>
{
    private bool _sorted;
    private PropertyDescriptor? _prop;
    private ListSortDirection _dir;

    public SortableBindingList(IEnumerable<T> items) : base(items.ToList()) { }

    protected override bool SupportsSortingCore => true;
    protected override bool IsSortedCore => _sorted;
    protected override PropertyDescriptor? SortPropertyCore => _prop;
    protected override ListSortDirection SortDirectionCore => _dir;

    //Just sorts the list.
    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        var cmp = Comparer<object?>.Default;
        ((List<T>)Items).Sort((a, b) =>
        {
            var c = cmp.Compare(prop.GetValue(a), prop.GetValue(b));
            return direction == ListSortDirection.Ascending ? c : -c;
        });
        _prop = prop; _dir = direction; _sorted = true;
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    protected override void RemoveSortCore() { _sorted = false; _prop = null; }
}

public static class GridHelper
{
    public static DataGridView Create()
    {
        var g = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            RowHeadersVisible = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
            BackgroundColor = SystemColors.Window,
            BorderStyle = BorderStyle.None,
        };
        g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 246, 250);
        return g;
    }

    //Binds rows and renames/formats columns: (property, header, format or null).
    public static void Show<T>(DataGridView grid, IEnumerable<T> rows, params (string Prop, string Header, string? Format)[] cols)
    {
        grid.DataSource = new SortableBindingList<T>(rows);
        foreach (var (prop, header, format) in cols)
        {
            var c = grid.Columns[prop];
            if (c is null) continue;
            c.HeaderText = header;
            if (format is not null) c.DefaultCellStyle.Format = format;
        }
    }

    public static void Clear(DataGridView grid) => grid.DataSource = null;

    public static GroupBox Boxed(string title, Control inner)
    {
        inner.Dock = DockStyle.Fill;
        var box = new GroupBox { Text = title, Dock = DockStyle.Fill, Padding = new Padding(6, 4, 6, 6) };
        box.Controls.Add(inner);
        return box;
    }

    public static Label Heading(string title, string hint) => new()
    {
        Text = title + "\n" + hint,
        AutoSize = true,
        Dock = DockStyle.Top,
        Padding = new Padding(10, 10, 10, 2),
        ForeColor = Color.FromArgb(70, 70, 70),
    };
}
