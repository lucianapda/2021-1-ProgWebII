import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public interface ControleRestauranteServer {

	@WebMethod public void Adicionar(Restaurante restaurante);
	
	@WebMethod public void AdicionarMesa(Restaurante restaurante, Mesa mesa);
	
	@WebMethod public void Alterar(Restaurante res, String nome, String numeroTele);
	
	@WebMethod public String Listar();
	
	@WebMethod public void Remover(Restaurante restaurante);
}
