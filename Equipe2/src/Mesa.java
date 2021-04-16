
public class Mesa {

	private int numero;
	private int QtdCadeiras;
	private Reserva reserva;
	private boolean disponivel;
	
	public Mesa(int numero, int qtdCadeiras, boolean disponivel) {
		super();
		setNumero(numero);
		setQtdCadeiras(qtdCadeiras);
		setDisponivel(disponivel);
	}
	
	public Reserva getReserva() {
		return reserva;
	}

	public void setReserva(Reserva reserva) {
		this.reserva = reserva;
		setDisponivel(false);
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
		if(!disponivel) {
			throw new IllegalArgumentException("Mesa já reservada ou ocupada");
		}
		this.disponivel = disponivel;
	}
	
	
	
}
