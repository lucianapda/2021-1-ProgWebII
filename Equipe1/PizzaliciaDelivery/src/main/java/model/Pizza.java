package model;

import javax.jws.WebMethod;
import javax.jws.WebService;

@WebService
public class Pizza {

	private String[] sabores;
	private int preco;
	private char tamanho;
	private int codigo;
	private int indice;

	public Pizza(char tamanho) {
		this.setTamanho(tamanho);
	}
	
	public Pizza() {
	}

	@WebMethod
	public void adicionarSabor(String sabor) {

		if (sabor == null) {
			throw new NullPointerException("Sabor nulo");
		}

		if (sabor.isEmpty()) {
			throw new IllegalArgumentException("Sabor n�o informado");
		}

		if (indice == getSabores().length) {
			throw new IllegalArgumentException("Limite de sabores alcan�ado");
		}

		this.getSabores()[indice] = sabor;
		indice++;
		System.out.println("sabor '" + sabor + "' adicionado � pizza.");
	}

	@WebMethod
	public void removerSabor(String sabor) {
		if (sabor == null) {
			throw new NullPointerException("sabor nulo");
		}

		if (sabor.isEmpty()) {
			throw new IllegalArgumentException("Informe um sabor v�lido");
		}

		if (this.contemSabor(sabor) == -1) {
			throw new IllegalArgumentException("Sabor n�o encontrado");
		}
		System.out.println("sabor '" + sabor + "' removido d pizza.");
	}

	private int contemSabor(String sabor) {
		for (int i = 0; i < this.getSabores().length; i++) {
			if (this.getSabores()[i] != null && this.getSabores()[i].equals(sabor)) {
				getSabores()[i] = null;
				indice--;
				return i;
			}
		}
		return -1;
	}

	@WebMethod
	public String[] getSabores() {
		return sabores;
	}

	@WebMethod
	public int getPreco() {
		return preco;
	}

	@WebMethod
	private void setPreco(int preco) {
		if (preco <= 0) {
			throw new IllegalArgumentException("Pre�o Inv�lido");
		}
		this.preco = preco;
	}

	@WebMethod
	public char getTamanho() {
		return tamanho;
	}

	@WebMethod
	public void setTamanho(char tamanho) {
		this.tamanho = tamanho;
		switch (tamanho) {
		case 'P':
			this.sabores = new String[2];
			this.setPreco(35);
			break;
		case 'M':
			this.sabores = new String[3];
			this.setPreco(55);
			break;
		case 'G':
			this.sabores = new String[4];
			this.setPreco(70);
			break;
		default:
			throw new IllegalArgumentException("o tamanho deve ser P, M ou G");
		}
	}

	@WebMethod
	public int getCodigo() {
		return codigo;
	}

	@WebMethod
	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

}