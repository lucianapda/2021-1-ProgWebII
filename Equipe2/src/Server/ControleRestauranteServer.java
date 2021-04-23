package Server;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public interface ControleRestauranteServer {

	@WebMethod
	public void Adicionar(Mesa mesa);
	
	
	@WebMethod
	public void Alterar(String nome, String numeroTele);
	
	@WebMethod
	public String Listar();
	
	@WebMethod
	public void Remover(Mesa mesa);
	
	public Restaurante getRestaurante();

	public void setRestaurante(Restaurante res);
}
