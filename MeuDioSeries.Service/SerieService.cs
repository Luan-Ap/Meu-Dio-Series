using AutoMapper;
using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuDioSeries.Service
{
    //Esta classe implementa a interface ISerieService utilizando o tipo SerieViewModel
    //Ela também é responsável por implementar o mapper definido na classe Startup.cs, fazendo o mapeamento entre os objetos Serie e SerieViewModel
    public class SerieService : ISerieService
    {
        private readonly ISerieRepositorio _serieRepositorio;
        private readonly IMapper _mapper;

        public SerieService(ISerieRepositorio serieRepositorio, IMapper mapper)
        {
            _serieRepositorio = serieRepositorio;
            _mapper = mapper;
        }

        public async Task AddAsync(SerieViewModel serieViewModel)
        {
            var serie = _mapper.Map<Serie>(serieViewModel);
            await _serieRepositorio.AddAsync(serie);
        }

        public async Task<IEnumerable<SerieViewModel>> GetAllAsync()
        {
            var seriesViewModel = _mapper.Map<IEnumerable<SerieViewModel>>(await _serieRepositorio.GetAllSeriesNaoExcluidasAsync());
            return seriesViewModel;
        }

        public async Task<SerieViewModel> GetByIdAsync(int id)
        {
            var serieViewModel = _mapper.Map<SerieViewModel>(await _serieRepositorio.GetSerieNaoExcluidaByIdAsync(id));
            return serieViewModel;
        }

        public async Task<IEnumerable<SerieViewModel>> GetSeriesByTitleAsync(string titulo)
        {
            var seriesViewModel = _mapper.Map<IEnumerable<SerieViewModel>>(await _serieRepositorio.GetSeriesByTitleAsync(titulo));

            return seriesViewModel;
        }

        public async Task RemoveAsync(SerieViewModel serieViewModel)
        {
            var serie = _mapper.Map<SerieViewModel, Serie>(serieViewModel);
            serie.Excluida = true;
            await _serieRepositorio.RemoveAsync(serie);
        }

        public async Task UpdateAsync (SerieViewModel serieViewModel)
        {
            var serie = _mapper.Map<Serie>(serieViewModel);
            await _serieRepositorio.UpdateAsync(serie);
        }
    }
}
