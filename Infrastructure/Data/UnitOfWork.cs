using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Infrastructure.Repositorios;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private PersonajeRepositorio _personajeRepositorio;
        private TiendaRepositorio _tiendaRepositorio;
        private ObjetoRepositorio _objetoRepositorio;
        private MisionRepositorio _misionRepositorio;
        private InventarioRepositorio _inventarioRepositorio;
        private EnemigoRepositorio _enemigoRepositorio;
        private BancoRepositorio _bancoRepositorio;
        private ObjetivoRepositorio _objetivoRepositorio;
        private RecompensaRepositorio _recompensaRepositorio;
        private Tipo_PersonajeRepositorio _tipo_PersonajeRepositorio;
        private UsuarioRepositorio _usuarioRepositorio;
        private SesionRepositorio _sesionRepositorio;
        
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IPersonajeRepositorio PersonajeRepositorio => _personajeRepositorio ??= new PersonajeRepositorio(_context);
        public ITiendaRepositorio TiendaRepositorio => _tiendaRepositorio ??= new TiendaRepositorio(_context);
        public IObjetoRepositorio ObjetoRepositorio => _objetoRepositorio ??= new ObjetoRepositorio(_context);
        public IMisionRepositorio MisionRepositorio => _misionRepositorio ??= new MisionRepositorio(_context);
        public IInventarioRepositorio InventarioRepositorio => _inventarioRepositorio ??= new InventarioRepositorio(_context);
        public IEnemigoRepositorio EnemigoRepositorio => _enemigoRepositorio ??= new EnemigoRepositorio(_context);
        public IBancoRepositorio BancoRepositorio => _bancoRepositorio ??= new BancoRepositorio(_context);
        public IObjetivoRepositorio ObjetivoRepositorio => _objetivoRepositorio ??= new ObjetivoRepositorio(_context);
        public IRecompensaRepositorio RecompensaRepositorio => _recompensaRepositorio ??= new RecompensaRepositorio(_context);
        public ITipo_PersonajeRepositorio Tipo_PersonajeRepositorio => _tipo_PersonajeRepositorio ??= new Tipo_PersonajeRepositorio(_context);
        public IUsuarioRepositorio UsuarioRepositorio => _usuarioRepositorio ??= new UsuarioRepositorio(_context);
        public ISesionRepositorio SesionRepositorio => _sesionRepositorio ??= new SesionRepositorio(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}