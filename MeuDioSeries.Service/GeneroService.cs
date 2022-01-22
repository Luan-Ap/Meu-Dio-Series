using AutoMapper;
using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuDioSeries.Service
{
    //Esta classe implementa a interface ISerieService utilizando o tipo generoViewModel
    //Ela também é responsável por implementar o mapper definido na classe Startup.cs, fazendo o mapeamento entre os objetos generoe generoViewModel
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IMapper _mapper;

        public GeneroService(IGeneroRepositorio generoRepositorio, IMapper mapper)
        {
            _generoRepositorio = generoRepositorio;
            _mapper = mapper;
        }

        public async Task Add(GeneroViewModel generoViewModel)
        {
            var genero= _mapper.Map<Genero>(generoViewModel);
            await _generoRepositorio.AddAsync(genero);
        }

        public async Task<IEnumerable<GeneroViewModel>> GetAll()
        {
            var generosViewModel = _mapper.Map<IEnumerable<GeneroViewModel>>(await _generoRepositorio.GetAllAsync());
            return generosViewModel;
        }

        public async Task<GeneroViewModel> GetById(int id)
        {
            var generoViewModel = _mapper.Map<GeneroViewModel>(await _generoRepositorio.GetByIdAsync(id));
            return generoViewModel;
        }

        public async Task Update (GeneroViewModel generoViewModel)
        {
            var genero = _mapper.Map<Genero>(generoViewModel);
            await _generoRepositorio.UpdateAsync(genero);
        }
    }
}
