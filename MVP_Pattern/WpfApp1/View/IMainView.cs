using System;
using System.Collections;
using System.Windows;

namespace MVPPattern.View
{
    public interface IMainView
    {
        event RoutedEventHandler OnLoaded;
        event RoutedEventHandler OnSave;
        event RoutedEventHandler OnDelete;
        event RoutedEventHandler OnCancel;
        event Action<object> OnListItemSelected;

        int Id { get; set; }
        string Name { get; set; }
        string Sex { get; set; }
        int Age { get; set; }
        IEnumerable ItemSource { get; set; } // 리스트 뷰 소스 데이터를 담기 위함
    }
}
