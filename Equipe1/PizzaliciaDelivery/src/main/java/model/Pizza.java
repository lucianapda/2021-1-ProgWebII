package model;

import javax.jws.WebMethod;

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

	public void adicionarSabor(String sabor) {

		if (sabor == null) {
			throw new NullPointerException("Sabor nulo");
		}

		if (sabor.isEmpty()) {
			throw new IllegalArgumentException("Sabor não informado");
		}

		if (indice == getSabores().length) {
			throw new IllegalArgumentException("Limite de sabores alcançado");
		}

		this.getSabores()[indice] = sabor;

		System.out.println("sabor '" + this.getSabores()[indice] + "' adicionado à pizza.");
		indice++;
	}

	public void removerSabor(String sabor) {
		if (sabor == null) {
			throw new NullPointerException("sabor nulo");
		}

		if (sabor.isEmpty()) {
			throw new IllegalArgumentException("Informe um sabor válido");
		}

		if (this.contemSabor(sabor) == -1) {
			throw new IllegalArgumentException("Sabor não encontrado");
		}
		System.out.println("sabor '" + sabor + "' removido d pizza.");
	}
	
	public void setSabores(String[] sabores) {
		this.sabores = sabores;
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

	public String[] getSabores() {
		return sabores;
	}

	public int getPreco() {
		return preco;
	}

	@WebMethod
	private void setPreco(int preco) {
		if (preco <= 0) {
			throw new IllegalArgumentException("Preço Inválido");
		}
		this.preco = preco;
	}

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

	public int getCodigo() {
		return codigo;
	}

	@WebMethod
	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

}
