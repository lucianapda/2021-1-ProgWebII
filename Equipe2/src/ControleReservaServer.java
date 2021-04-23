import javax.jws.WebService;

import java.time.LocalDate;

import javax.jws.WebMethod;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public interface ControleReservaServer {

	@WebMethod public void Adicionar(Reserva reserva);
	
	@WebMethod public void Alterar(Reserva reserva, String nome, int qtdpessoas, String numeroCon, 
									LocalDate dataReserva, int duracao);
	
	@WebMethod public String Listar();
	
	@WebMethod public void remove(Reserva reserva);
}
