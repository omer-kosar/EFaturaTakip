using System.Collections.ObjectModel;

namespace EFaturaTakip.DTO.UyumSoft
{
    public class EFaturaListModel
    {
        public EFatura SelectedFatura { get; set; }
        public ObservableCollection<EFatura> SelectedFaturalar { get; set; }
        public ObservableCollection<EFatura> Faturalar { get; set; }
    }
}
