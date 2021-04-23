package Server;
import java.util.HashMap;

public class Restaurante {

	private String Nome;
	private String NumeroTelefone;
	
	public HashMap<Integer, Mesa> mesas = new HashMap<>();		
	
	public Restaurante() {
	}
	
	public void addMesa(Mesa m) {
		if(m == null) {
			throw new IllegalArgumentException("Mesa não pode ser nulo");
		}
		if(mesas.containsKey(m.getNumero())) {
			throw new IllegalArgumentException("Já a mesa com esse número");
		}
		this.mesas.put(m.getNumero(), m);
	}

	public String getNome() {
		return Nome;
	}

	public void setNome(String nome) {
		if(nome == null || nome.isEmpty()) {
			throw new IllegalArgumentException("Nome pode ser vazio");
		}
		Nome = nome;
	}

	public String getNumeroTelefone() {
		return NumeroTelefone;
	}

	public void setNumeroTelefone(String numeroTelefone) {
		if(numeroTelefone == null || numeroTelefone.length() == 8)
		NumeroTelefone = numeroTelefone;
	}
	
	public int QtdMesas() {
		return mesas.size();
	}
	
	public String toString() {
		return "Nome do Restaurante: "+getNome()+"\nNúmero de Telefone: "+getNumeroTelefone()
		+"\nQuantidade de Mesas: "+QtdMesas()+"\n";
	}

	public void removerMesa(Mesa mesa) {
		for(Mesa mes : mesas.values()) {
			if(mes.getNumero() == mesa.getNumero()) {
				mesas.remove(mes.getNumero());
				break;
			}
		}
	}
	
	public void Alter(String nome, String tele) {
		setNome(nome);
		setNumeroTelefone(tele);
	}
}
