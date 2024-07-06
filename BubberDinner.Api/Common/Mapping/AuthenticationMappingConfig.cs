using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contracts.Authentication;
using Mapster;

namespace BubberDinner.Api.Common.Mapping;
public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Esses dois configs não seriam necessários pos os conteúdos são identicos, porém é bom manter para ficarem explícitos os mapeamentos
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            // .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);

    }
}
