import java.util.ArrayList;

public class ControleMesa {

	private ArrayList<Mesa> Mesas = new ArrayList<>();
	
	public void Adicionar(Mesa mesa) {
		Mesas.add(Mesa);
	}
	
	public void Alterar(Mesa res, String nome, String numeroTele) {
		if(nome != null) {
			res.setNome(nome);
		}else if(numeroTele != null) {
			res.setNumeroTelefone(numeroTele);
		}
	}
	
	public String Listar(){
		String str = "";
		for (Mesa mesa : mesas) {
			str += Mesa.toString();
		}
		return str;
	}
	
	public void Remover(Mesa mesa) {
		Mesas.remove(mesa);
	}