package Server;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public interface ControleMesaServer {

	@WebMethod public void Adicionar(Mesa mesa);
	@WebMethod public void Alterar(boolean status, int qtdCadeiras, Mesa mesa);
	@WebMethod public String Listar();
	
}