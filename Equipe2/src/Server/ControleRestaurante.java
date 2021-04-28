package Server;
import java.util.ArrayList;
import java.util.Date;

import javax.jws.WebMethod;
import javax.jws.WebService;

@WebService(endpointInterface = "Server.ControleRestauranteServer")
public class ControleRestaurante implements ControleRestauranteServer{
	
	private Restaurante restaurante;

	public ControleRestaurante() {		
		this.setRestaurante(new Restaurante());
	}

	public void Adicionar(Mesa mesa) {
		this.getRestaurante().addMesa(mesa);
	}
	
	
	public void Alterar(String nome, String numeroTele) {
		this.getRestaurante().Alter(nome, numeroTele);
		
	}
	
	public String Listar(){
		return this.getRestaurante().toString();
	}
	
	public void Remover(Mesa mesa) {
		this.getRestaurante().removerMesa(mesa);
	}
	
	public Restaurante getRestaurante() {
		return restaurante;
	}

	public void setRestaurante(Restaurante res) {
		this.restaurante = res;
	}
}

