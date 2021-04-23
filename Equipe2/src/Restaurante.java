import java.util.HashMap;

public class Restaurante {

	private String Nome;
	private String NumeroTelefone;
	
	public HashMap<Integer, Mesa> mesas = new HashMap<>();	
	
	public Restaurante(String nome, String numeroTelefone) {
		super();
		setNome(nome);
		setNumeroTelefone(numeroTelefone);
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
	
	public int QtdMesasDisponiveis() {
		int qtd = 0;
		for (Mesa m : mesas.values()) {
			if(m.isDisponivel()) {
				qtd++;
			}
		}
		return qtd;
	}
	
	public String toString() {
		return "Nome do Restaurante: "+getNome()+"\nNúmero de Telefone: "+getNumeroTelefone()
		+"\nQuantidade de mesas disponiveis: "+QtdMesasDisponiveis()+"\n";
	}

}
