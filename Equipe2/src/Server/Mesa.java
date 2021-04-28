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
			throw new IllegalArgumentException("N�mero da mesa n�o pode ser menor ou igual a 0");
		}
		this.numero = numero;
	}

	public int getQtdCadeiras() {
		return QtdCadeiras;
	}

	public void setQtdCadeiras(int qtdCadeiras) {
		if(qtdCadeiras <= 0) {
			throw new IllegalArgumentException("Quantidades de cadeiras n�o pode ser menor ou igual a 0");
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
		return "N�mero da mesa:"+getNumero()+"\nQuantidade de cadeiras: "+getQtdCadeiras()
		+"\nEst� disponivel: "+isDisponivel()+"\n";
	}
	
}
