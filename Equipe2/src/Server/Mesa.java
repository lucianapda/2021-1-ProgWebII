package Server;

public class Mesa {

	private int numero;
	private int QtdCadeiras;
	private boolean disponivel;
	
	public Mesa() {
	}
	

	public int getNumero() {
		return numero;
	}

	public void setNumero(int numero) {
		if(numero <= 0) {
			throw new IllegalArgumentException("Número da mesa não pode ser menor ou igual a 0");
		}
		this.numero = numero;
	}

	public int getQtdCadeiras() {
		return QtdCadeiras;
	}

	public void setQtdCadeiras(int qtdCadeiras) {
		if(qtdCadeiras <= 0) {
			throw new IllegalArgumentException("Quantidades de cadeiras não pode ser menor ou igual a 0");
		}
		QtdCadeiras = qtdCadeiras;
	}

	public boolean isDisponivel() {
		return disponivel;
	}

	public void setDisponivel(boolean disponivel) {
		this.disponivel = disponivel;
	}
	
	public String toString() {
		return "Número da mesa:"+getNumero()+"\nQuantidade de cadeiras: "+getQtdCadeiras()
		+"\nEstá disponivel: "+isDisponivel()+"\n";
	}
	
}
