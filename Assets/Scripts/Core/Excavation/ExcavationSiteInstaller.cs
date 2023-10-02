using Core.Excavation.Site.Model;
using Core.Excavation.Site.Presenter;
using Core.Excavation.Site.View;
using UnityEngine;

namespace Core.Excavation
{
    public class ExcavationSiteInstaller : MonoBehaviour
    {
        [SerializeField] private ExcavationSiteView _view;
        [SerializeField] private ExcavationSiteSettings _settings;

        private ExcavationSitePresenter _site;

        public void Start()
        {
            _site = new(_view, _settings);
        }
    }
}