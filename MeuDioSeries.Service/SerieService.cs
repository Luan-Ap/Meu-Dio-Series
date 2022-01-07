using AutoMapper;
using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using System.Collections.Generic;

namespace MeuDioSeries.Service
{
    public class SerieService : ISerieService<SerieViewModel>
    {
        private readonly ISerieRepositorio<Serie> _serieRepositorio;
        private readonly IMapper _mapper;

        public SerieService(ISerieRepositorio<Serie> serieRepositorio, IMapper mapper)
        {
            _serieRepositorio = serieRepositorio;
            _mapper = mapper;
        }

        public void Add(SerieViewModel serieViewModel)
        {
            var serie = _mapper.Map<Serie>(serieViewModel);
            _serieRepositorio.Add(serie);
        }

        public IEnumerable<SerieViewModel> GetAll()
        {
            var seriesViewModel = _mapper.Map<IEnumerable<SerieViewModel>>(_serieRepositorio.GetAll());
            return seriesViewModel;
        }

        public SerieViewModel GetById(int id)
        {
            var serieViewModel = _mapper.Map<SerieViewModel>(_serieRepositorio.GetById(id));
            return serieViewModel;
        }

        public void Remove(SerieViewModel serieViewModel)
        {
            var serie = _mapper.Map<SerieViewModel, Serie>(serieViewModel);
            _serieRepositorio.Remove(serie);
        }

        public void Update(SerieViewModel serieViewModel)
        {
            var serie = _mapper.Map<Serie>(serieViewModel);
            _serieRepositorio.Update(serie);
        }
    }
}
