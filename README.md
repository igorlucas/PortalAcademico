# Portal Academico 
# Projeto para o controle e gestão de uma entidade educacional. 

**Levantamento inicial dos requisitos:**

Uma determinada escola atua no ramo de educação do ensino fundamental e médio. Com o crescimento da demanda, a escola percebeu que não seria possível o gerenciamento da escola manualmente, como era feito até hoje. Inicialmente, será desenvolvido apenas o gerenciamento acadêmico.

Algumas características do sistema:

◦ O sistema deverá haver um sistema de gerenciamento de permissões, de forma que existam as seguintes permissões: coordenador, professor, aluno e administrador do sistema. Dessa forma, deverá haver uma tela de login no sistema e um sistema de auto registro dos alunos, mediante a confirmação de dados previamente cadastrados pelo coordenador.

◦ Geração de relatórios: Listagem de alunos, Listagem de professores, Quantitativo de alunos, lista de usuários. Para a geração dos relatórios, deverão ser criadas telas para aplicação de filtros (ex: por série, por turma etc)

◦ Cadastro de usuários (devendo ser feito o relacionamento com o vínculo = professor, aluno, coordenador). Funcionalidade de recuperar senha.

◦ O sistema deverá proporcionar uma forma de realizar auditoria nas operações realizadas pelos usuários (deverá estar disponível apenas para o administrador do sistema).

◦ Em cada turma cadastrada no sistema, deverá haver um fórum vinculado, que servirá para a troca de informações entre os professores e alunos, e entre os próprios alunos. Também poderá ser usado para o envio de avisos.

**O coordenador** terá as seguintes funções:

▪ Registro do calendário acadêmico: serão especificadas datas como:

início do semestre, período de provas, data limite de lançamento das notas, férias, período de matrícula, data de liberação do boletim e feriados. Em determinados eventos (por exemplo, liberação do boletim), o sistema deverá realizar ações específicas (no exemplo citado, seria a liberação do boletim para acesso a partir do aluno).

▪ CRUD dos dados de professores: nome, CPF, data de nascimento,

e-mail, telefone(s), endereço e formação.

▪ CRUD para os dados dos alunos: matrícula (gerada automaticamente), nome, nome da mãe, data de nascimento, ano de ingresso, série de ingresso e série atual (deve haver o cuidado de manter o histórico das séries cursadas pelo aluno)

▪ CRUD de disciplinas: nome da disciplina, série (a qual a disciplina

está associada), Conteúdo Programático,

▪ CRUD de turmas: código da turma, disciplina (à qual está vinculada), ano em que foi ofertada, professor responsável, sala e horário. Com relação ao horário, deve haver o cuidado de não permitir o choque de duas turmas da mesma série serem ofertadas no mesmo horário.

▪ Emissão do boletim do aluno, podendo essa operação ser realizada em qualquer momento no ano (gerar também no formado de impressão).

▪ Lançamento de notas dos alunos em determinada turma (no caso

em que o professor não lançou as notas).

▪ Realização da matrícula de um aluno em uma série (e

consequentemente, em todas as disciplinas da série escolhida)

▪ Verificar as provas submetidas pelos professores nas turmas.

◦ **Professor:**

▪ Lançamento de Nota (as provas são bimestrais, tendo um total de 4 ao ano)

▪ Lançamento de Frequência dos dias de aula e do conteúdo que foi visto.

▪ Impressão da lista de frequência

▪ Impressão do mapa de notas da disciplina contendo a matrícula, nome e as notas do aluno na disciplina.

▪ Submissão de prova

◦ **Aluno:**

▪ Emissão de declaração

▪ Verificar a sua situação na turma (notas e frequência).

▪ Verificar o conteúdo visto na turma em determinado dia.

▪ Solicitar matrícula para o ano seguinte (desde que esteja no período)

▪ Emissão de atestado

◦ **Administrador do Sistema:** todas as operações descritas para os perfis anteriores.
