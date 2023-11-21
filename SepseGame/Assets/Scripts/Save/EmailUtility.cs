using UnityEngine;
using System.ComponentModel;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using System.Net.Mime;

public class EmailUtility : MonoBehaviour
{
    public Caso1 generalManager;
    public FeedbackManager fbManager;
    public FeedbackHospital fbHospital;
    public PranchetaManager prnchManager;
    public Pacote condutasManager;
    public EmailSend emailSender;

    public string auxTime;

    int numCasoCurrent;
    string txtAux;
    string[,] caso0 = new string[8, 14];
    string[,] caso1 = new string[8, 14];
    string[,] caso2 = new string[8, 14];
    string[,] caso3 = new string[8, 14];
    string[,] caso4 = new string[8, 14];
    string[,] caso5 = new string[8, 14];
    string[,] caso6 = new string[8, 14];
    string[,] caso7 = new string[8, 14];
    string[,] caso8 = new string[8, 14];
    string[,] caso9 = new string[8, 14];
    string[,] caso10 = new string[8, 14];
    string[,] caso11 = new string[8, 14];
    string[,] caso12 = new string[8, 14];

    string resultsAux;

    public static string results0;
    public static string results1;
    public static string results2;
    public static string results3;
    public static string results4;
    public static string results5;
    public static string results6;
    public static string results7;
    public static string results8;
    public static string results9;
    public static string results10;
    public static string results11;
    public static string results12;

    public void SaveEmail()
    {
        numCasoCurrent = generalManager.Caso - 1;
        SelecaoCaso(numCasoCurrent);
        if(emailSender != null)
        {
            Debug.Log("chegou na parte de enviar o email");
            emailSender.SendEmail();
        }
    }

    /*string ConvertTime()
    {
        float minutes = Mathf.FloorToInt(caso.time / 60);
        float seconds = Mathf.FloorToInt(caso.time % 60);

        auxTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return auxTime;
    }*/

    void SelecaoCaso(int numCasoCurrent)
    {
        switch (numCasoCurrent)
        {
            case 0:
                //pontuacao
                caso0[0, 0] = fbManager.estrelas.ToString();
                //caso0[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso0);
                //erros
                SaveErros(caso0);
                //naomarcados
                SaveNaoMarcados(caso0);
                //Correcao do caso para mostrar no email
                results0 = correctMatrix(caso0);
                if(EmailSend.nVezes0 <= 0)
                {
                    EmailSend.resultado0R = results0;
                }
                EmailSend.nVezes0 += 1;
                break;
            case 1:
                //pontuacao
                caso1[0, 0] = fbManager.estrelas.ToString();
                //caso1[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso1);
                //erros
                SaveErros(caso1);
                //naomarcados
                SaveNaoMarcados(caso1);
                //acertocondutas
                //SaveCondutasCertas(caso1);
                //erroscondutas
                //SaveCondutasCertas(caso1);
                //avisos
                //SaveAvisos(caso1);
                //Correcao do caso para mostrar no email
                results1 = correctMatrix(caso1);
                if (EmailSend.nVezes1 <= 0)
                {
                    EmailSend.resultado1R = results1;
                }
                EmailSend.nVezes1 += 1;
                break;
            case 2:
                //pontuacao
                caso2[0, 0] = fbManager.estrelas.ToString();
                //caso2[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso2);
                //erros
                SaveErros(caso2);
                //naomarcados
                SaveNaoMarcados(caso2);
                //acertocondutas
                //SaveCondutasCertas(caso2);
                //erroscondutas
                //SaveCondutasCertas(caso2);
                //avisos
                //SaveAvisos(caso2);
                //Correcao do caso para mostrar no email
                results2 = correctMatrix(caso2);
                if (EmailSend.nVezes2 <= 0)
                {
                    EmailSend.resultado2R = results2;
                }
                EmailSend.nVezes2 += 1;
                break;
            case 3:
                //pontuacao
                caso3[0, 0] = fbManager.estrelas.ToString();
                //caso3[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso3);
                //erros
                SaveErros(caso3);
                //naomarcados
                SaveNaoMarcados(caso3);
                //acertocondutas
                //SaveCondutasCertas(caso3);
                //erroscondutas
                //SaveCondutasCertas(caso3);
                //avisos
                //SaveAvisos(caso3);
                //Correcao do caso para mostrar no email
                results3 = correctMatrix(caso3);
                if (EmailSend.nVezes3 <= 0)
                {
                    EmailSend.resultado3R = results3;
                }
                EmailSend.nVezes3 += 1;
                break;
            case 4:
                //pontuacao
                caso4[0, 0] = fbManager.estrelas.ToString();
                //caso4[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso4);
                //erros
                SaveErros(caso4);
                //naomarcados
                SaveNaoMarcados(caso4);
                //acertocondutas
                //SaveCondutasCertas(caso4);
                //erroscondutas
                //SaveCondutasCertas(caso4);
                //avisos
                //SaveAvisos(caso4);
                //Correcao do caso para mostrar no email
                results4 = correctMatrix(caso4);
                if (EmailSend.nVezes4 <= 0)
                {
                    EmailSend.resultado4R = results4;
                }
                EmailSend.nVezes4 += 1;
                break;
            case 5:
                //pontuacao
                caso5[0, 0] = fbManager.estrelas.ToString();
                //caso5[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso5);
                //erros
                SaveErros(caso5);
                //naomarcados
                SaveNaoMarcados(caso5);
                //acertocondutas
                //SaveCondutasCertas(caso5);
                //erroscondutas
                //SaveCondutasCertas(caso5);
                //avisos
                //SaveAvisos(caso5);
                //Correcao do caso para mostrar no email
                results5 = correctMatrix(caso5);
                if (EmailSend.nVezes5 <= 0)
                {
                    EmailSend.resultado5R = results5;
                }
                EmailSend.nVezes5 += 1;
                break;
            case 6:
                //pontuacao
                caso6[0, 0] = fbManager.estrelas.ToString();
                //caso6[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso6);
                //erros
                SaveErros(caso6);
                //naomarcados
                SaveNaoMarcados(caso6);
                //acertocondutas
                //SaveCondutasCertas(caso6);
                //erroscondutas
                //SaveCondutasCertas(caso6);
                //avisos
                //SaveAvisos(caso6);
                //Correcao do caso para mostrar no email
                results6 = correctMatrix(caso6);
                if (EmailSend.nVezes6 <= 0)
                {
                    EmailSend.resultado6R = results6;
                }
                EmailSend.nVezes6 += 1;
                break;
            case 7:
                //pontuacao
                caso7[0, 0] = fbManager.estrelas.ToString();
                //caso7[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso7);
                //erros
                SaveErros(caso7);
                //naomarcados
                SaveNaoMarcados(caso7);
                //acertocondutas
                //SaveCondutasCertas(caso7);
                //erroscondutas
                //SaveCondutasCertas(caso7);
                //avisos
                //SaveAvisos(caso7);
                //Correcao do caso para mostrar no email
                results7 = correctMatrix(caso7);
                if (EmailSend.nVezes7 <= 0)
                {
                    EmailSend.resultado7R = results7;
                }
                EmailSend.nVezes7 += 1;
                break;
            case 8:
                //pontuacao
                caso8[0, 0] = fbManager.estrelas.ToString();
                //caso8[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso8);
                //erros
                SaveErros(caso8);
                //naomarcados
                SaveNaoMarcados(caso8);
                //acertocondutas
                //SaveCondutasCertas(caso8);
                //erroscondutas
                //SaveCondutasCertas(caso8);
                //avisos
                //SaveAvisos(caso8);
                //Correcao do caso para mostrar no email
                results8 = correctMatrix(caso8);
                if (EmailSend.nVezes8 <= 0)
                {
                    EmailSend.resultado8R = results8;
                }
                EmailSend.nVezes8 += 1;
                break;
            case 9:
                //pontuacao
                caso9[0, 0] = fbManager.estrelas.ToString();
                // caso9[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso9);
                //erros
                SaveErros(caso9);
                //naomarcados
                SaveNaoMarcados(caso9);
                //acertocondutas
                //SaveCondutasCertas(caso9);
                //erroscondutas
                //SaveCondutasCertas(caso9);
                //avisos
                //SaveAvisos(caso9);
                //Correcao do caso para mostrar no email
                results9 = correctMatrix(caso9);
                if (EmailSend.nVezes9 <= 0)
                {
                    EmailSend.resultado9R = results9;
                }
                EmailSend.nVezes9 += 1;
                break;
            case 10:
                //pontuacao
                caso10[0, 0] = fbManager.estrelas.ToString();
                //caso10[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso10);
                //erros
                SaveErros(caso10);
                //naomarcados
                SaveNaoMarcados(caso10);
                //acertocondutas
                //SaveCondutasCertas(caso10);
                //erroscondutas
                //SaveCondutasCertas(caso10);
                //avisos
                //SaveAvisos(caso10);
                //Correcao do caso para mostrar no email
                results10 = correctMatrix(caso10);
                if (EmailSend.nVezes10 <= 0)
                {
                    EmailSend.resultado10R = results10;
                }
                EmailSend.nVezes10 += 1;
                break;
            case 11:
                //pontuacao
                caso11[0, 0] = fbManager.estrelas.ToString();
                //caso11[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso11);
                //erros
                SaveErros(caso11);
                //naomarcados
                SaveNaoMarcados(caso11);
                //acertocondutas
                //SaveCondutasCertas(caso11);
                //erroscondutas
                //SaveCondutasCertas(caso11);
                //avisos
                //SaveAvisos(caso11);
                //Correcao do caso para mostrar no email
                results11 = correctMatrix(caso11);
                if (EmailSend.nVezes11 <= 0)
                {
                    EmailSend.resultado11R = results11;
                }
                EmailSend.nVezes11 += 1;
                break;
            case 12:
                //pontuacao
                caso12[0, 0] = fbManager.estrelas.ToString();
                //caso12[7, 0] = ConvertTime();
                //acertos
                SaveAcertos(caso12);
                //erros
                SaveErros(caso12);
                //naomarcados
                SaveNaoMarcados(caso12);
                //acertocondutas
                //SaveCondutasCertas(caso12);
                //erroscondutas
                //SaveCondutasCertas(caso12);
                //avisos
                //SaveAvisos(caso12);
                //Correcao do caso para mostrar no email
                results12 = correctMatrix(caso12);
                if (EmailSend.nVezes12 <= 0)
                {
                    EmailSend.resultado12R = results12;
                }
                EmailSend.nVezes12 += 1;
                break;
            default:
                break;
        }
    }

    void SaveAcertos(string[,] x)
    {
        int contA = 0;
        for (int i = 0; i < 14; i++)
        {
            if (fbHospital.corretas.Contains(i) && prnchManager.selecionados.Contains(i))
            {
                txtAux = IndiceDoSinalVital(i);
                x[1, contA] = txtAux;
                contA++;
            }
        }

    }

    void SaveErros(string[,] j)
    {
        int contE = 0;
        for (int i = 0; i < 14; i++)
        {
            if (!fbHospital.corretas.Contains(i) && prnchManager.selecionados.Contains(i))
            {
                txtAux = null;
                txtAux = IndiceDoSinalVital(i);
                j[2, contE] = txtAux;
                contE++;
            }
        }
    }

    void SaveNaoMarcados(string[,] k)
    {
        int contNM = 0;
        for (int i = 0; i < 14; i++)
        {
            if (fbHospital.corretas.Contains(i) && !prnchManager.selecionados.Contains(i))
            {
                txtAux = null;
                txtAux = IndiceDoSinalVital(i);
                k[3, contNM] = txtAux;
                contNM++;
            }
        }
    }

    /*void SaveCondutasCertas(string[,] z)
    {
        int contCC = 0;
        for (int i = 0; i < 6; i++)
        {
            if (condutasManager.condutas[i] == condutasManager.condutas[condutasManager.selecaoCondutas[i]])
            {
                txtAux = null;
                txtAux = IndiceDaConduta(i);
                z[4, contCC] = txtAux;
                contCC++;
            }
        }
    }*/

    /*void SaveCondutasCertas(string[,] b)
    {
        int contCE = 0;
        for (int i = 0; i < 6; i++)
        {
            if (condutasManager.condutas[i] != condutasManager.condutas[condutasManager.selecaoCondutas[i]])
            {
                txtAux = null;
                txtAux = IndiceDaConduta(i);
                b[5, contCE] = txtAux;
                contCE++;
            }
        }
    }*/

    /*void SaveAvisos(string[,] sx)
    {
        int slot = 0;
        if (!caso.abriuProtocolo)
        {
            sx[6, slot] = "O Protocolo de Sepse não foi aberto!";
            slot++;
        }
        if (!caso.chamouEquipe)
        {
            sx[6, slot] = "A Equipe Médica não foi acionada!";
            slot++;
        }
        if (!caso.apertouBotaoCorreto)
        {
            if (caso.buttonCorreto == 1)
            {
                sx[6, slot] = "O Protocolo de Sepse deveria ter sido descontinuado!";
                slot++;
            }
            else
            {
                sx[6, slot] = "O Protocolo de Sepse deveria ter sido continuado!";
                slot++;
            }
        }
    }*/
    string IndiceDoSinalVital(int contador)
    {
        switch (contador)
        {
            case 0:
                return prnchManager.SinaisVitais[0];
            case 1:
                return prnchManager.SinaisVitais[1];
            case 2:
                return prnchManager.SinaisVitais[2];
            case 3:
                return prnchManager.SinaisVitais[3];
            case 4:
                return prnchManager.SinaisVitais[4];
            case 5:
                return prnchManager.SinaisVitais[5];
            case 6:
                return prnchManager.SinaisVitais[6];
            case 7:
                return prnchManager.SinaisVitais[7];
            case 8:
                return prnchManager.SinaisVitais[8];
            case 9:
                return prnchManager.SinaisVitais[9];
            case 10:
                return prnchManager.Lab[0];
            case 11:
                return prnchManager.Lab[1];
            case 12:
                return prnchManager.Lab[2];
            case 13:
                return prnchManager.Lab[3];
            default:
                return null;
        }
    }

    string IndiceDaCondutaCerta(int contador)
    {
        switch (contador)
        {
            case 0:
                return condutasManager.condutas[0];
            case 1:
                return condutasManager.condutas[1];
            case 2:
                return condutasManager.condutas[2];
            case 3:
                return condutasManager.condutas[3];
            case 4:
                return condutasManager.condutas[4];
            case 5:
                return condutasManager.condutas[5];
            default:
                return null;
        }
    }

    string IndiceDaCondutaMarcada(int contador)
    {
        switch (contador)
        {
            case 0:
                return condutasManager.condutas[condutasManager.selecaoCondutas[0]];
            case 1:
                return condutasManager.condutas[condutasManager.selecaoCondutas[1]];
            case 2:
                return condutasManager.condutas[condutasManager.selecaoCondutas[2]];
            case 3:
                return condutasManager.condutas[condutasManager.selecaoCondutas[3]];
            case 4:
                return condutasManager.condutas[condutasManager.selecaoCondutas[4]];
            case 5:
                return condutasManager.condutas[condutasManager.selecaoCondutas[5]];
            default:
                return null;
        }
    }

    /*string CorrigirMatriz(string[,] res)
    {
        string[,] aux2;
        aux2 = res;
        for (int f=0; f < 8; f++)
        {
            for (int j=0; j<14;j++)
            {
                if (res[f,j] == null || res[f, j] == string.Empty)
                {
                    res[f,j] = "-";
                }
            }
        }

        resultsAux = string.Join("\n",
              Enumerable.Range(0, res.GetUpperBound(0) + 1)
             .Select(x => Enumerable.Range(0, res.GetUpperBound(1) + 1)
             .Select(y => res[x, y]))
             .Select(z => string.Join($"; ", z)));

        return resultsAux;
    }*/

    string correctMatrix(string[,] matrix)
    {
        string resultString = "";
        resultString += "ESTRELAS OBTIDAS: " + matrix[0, 0];
        
        resultString += "\n\nSINAIS MARCADOS CORRETAMENTE:";
        for (int i=0; i < matrix.GetLength(1); i++)
        {
            if (matrix[1,i] != null)
            {
                resultString += "\n- " + matrix[1, i];
            }
        }
        resultString += "\n\nSINAIS MARCADOS INCORRETAMENTE:";
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[2, j] != null)
            {
                resultString += "\n- " + matrix[2, j];
            }
        }
        resultString += "\n\nSINAIS NÃO MARCADOS:";
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            if (matrix[3, k] != null)
            {
                resultString += "\n- " + matrix[3, k];
            }
        }

        resultString += "\n\nCONDUTAS SELECIONADAS: ";
        for (int x=0; x < 6; x++)
        {
            resultString += "\n- " + IndiceDaCondutaMarcada(x);
        }
        resultString += "\n\nCONDUTAS CORRETAS (para referência): ";
        for (int y = 0; y < 6; y++)
        {
            resultString += "\n- " + IndiceDaCondutaCerta(y);
        }

        return resultString;
    }
}
