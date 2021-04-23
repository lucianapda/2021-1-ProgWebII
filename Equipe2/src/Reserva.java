import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

public class Reserva {

	private String Nome;
	private int QtdPessoas;
	private String NumeroContato;
	private LocalDate DataReserva;
	private int duracao;
	private Mesa mesa;
	
	public Reserva(String nome, int qtdPessoas, String numeroContato, LocalDate dataReserva, int duracao, Mesa mesa) {
		super();
		setNome(nome);
		setQtdPessoas(qtdPessoas);
		setNumeroContato(numeroContato);
		setDataReserva(dataReserva);
		setDuracao(duracao);
		setMesa(mesa);
	}
	
	public String getNome() {
		return Nome;
	}
	
	public void setNome(String nome) {
		if(nome == null || nome.isEmpty()) {
			throw new IllegalArgumentException("Nome não pode ser vazio");
		}
		Nome = nome;
	}
	
	public int getQtdPessoas() {
		return QtdPessoas;
	}
	
	public void setQtdPessoas(int qtdPessoas) {
		if(qtdPessoas <= 0) {
			throw new IllegalArgumentException("Quantidade de pessoas não pode ser menor ou igual a 0");
		}
		QtdPessoas = qtdPessoas;
	}
	
	public String getNumeroContato() {
		return NumeroContato;
	}
	
	public void setNumeroContato(String numeroContato) {
		if(numeroContato == null || numeroContato.isEmpty()) {
			throw new IllegalArgumentException("Número de contato não pode ser vazio");
		}
		NumeroContato = numeroContato;
	}
	
	public LocalDate getDataReserva() {
		return DataReserva;
	}
	
	public void setDataReserva(LocalDate dataReserva) {
		DateTimeFormatter data = DateTimeFormatter.ofPattern("dd/MM/yyyy");
		LocalDate dataAtual = LocalDate.now();
		data.format(dataAtual);
		data.format(dataReserva);
		if(dataReserva == null || dataReserva.isBefore(dataAtual)) {
			throw new IllegalArgumentException("Data da reserva não pode ser vazio ou menor que a data atual");
		}
		DataReserva = dataReserva;
	}
	
	public int getDuracao() {
		return duracao;
	}
	
	public void setDuracao(int duracao) {
		if(duracao <= 0) {
			throw new IllegalArgumentException("Tempo de duração não pode ser menor ou igual a 0");
		}
		this.duracao = duracao;
	}
	
	public Mesa getMesa() {
		return mesa;
	}
	
	public void setMesa(Mesa mesa) {
		if(mesa == null) {
			throw new IllegalArgumentException("Mesa não pode ser nulo");
		}
		this.mesa = mesa;
	}
	
	public String toString() {
		return "Nome reserva: "+Nome+"\nQuantidade de pessoas: "+QtdPessoas
				+"\nData da reserva: "+DataReserva+"\nMesa Reservada: "+mesa.getNumero()+"\n";
	}
}
