using BTAS.BlazorApp.Models;
using System;
using System.Collections.Generic;

namespace BTAS.BlazorApp.Services
{
    public class ApplicationState
    {
        public string SelectedTab { get; private set; }
        public List<TabModel> tabs { get; private set; } = new();
        public SearchFilter filter { get; set; }
        public string pageTitle { get; set; } = "";

        public event Action OnChange;

        public void AddTab(TabModel tab)
        {
            foreach(var t in tabs)
            {
                t.IsActive = false;
            }
            SelectedTab = tab.Name;
            tabs.Add(tab);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
