﻿using FireSense.WebApi.Model.Entities;

namespace FireSense.WebApi.Model.Interfaces
{
    public interface ILocalizacaoRepository
    {
        void Add(Localizacao localizacao);

        Localizacao ObterCodLocal(int codUsuario);
    }
}
