import java.util.ArrayList;
import java.util.Date;
import javax.jws.WebService;

@WebService(endpointInterface = "ControleRestauranteServer")
public class ControleRestaurante implements ControleRestauranteServer{

	public ArrayList<Restaurante> restaurantes = new ArrayList<>();
	
	public void Adicionar(Restaurante restaurante) {
		restaurantes.add(restaurante);
	}
	
	public void AdicionarMesa(Restaurante restaurante, Mesa mesa) {
		for(Restaurante rest : restaurantes) {
			if(restaurante.equals(rest)) {
				rest.addMesa(mesa);
			}
		}
	}
	
	public void Alterar(Restaurante res, String nome, String numeroTele) {
		for (Restaurante restaurante : restaurantes) {
			if(restaurante.getNome() == nome) {
				restaurante.setNome(nome);
				restaurante.setNumeroTelefone(numeroTele);
			}
		}
		
	}
	
	public String Listar(){
		String str = "";
		for (Restaurante restaurante : restaurantes) {
			str += restaurante.toString();
		}
		return str;
	}
	
	public void Remover(Restaurante restaurante) {
		restaurantes.remove(restaurante);
	}

}
