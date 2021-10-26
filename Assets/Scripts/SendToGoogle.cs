using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendToGoogle : MonoBehaviour
{
    public GameManager manager;

    //email stuff required. Unsafe: use a burner email on 000webhost
    const string webhostURL = "https://lgmtest.000webhostapp.com/Emailer2.php";

    //email text parts. Emails are in HTML (they're online)
    const string messagePart1 = ", congrats on your win!<br><br>" +
        "You finished the Let\'s Go Marketing game first, so you win a free Ferris State Marketing shirt! All we need is for you to click the following link and enter your information into the form.<br><br>" +
        "<a href=\"https://www.typeform.com/\">Score Your Free Merch Here</a><br><br>";
    const string messagePart2 = " for your career choice! Awesome pick!<br><br>";
    const string messagePart3 = "Here is some more information related to this selection:<br><br>" +
        "<a href=\"https://graphicdesign.ferris.edu/\">Ferris State Design Program Page</a><br>" +
        "<a href=\"https://www.ferris.edu/admissions/schedule_visit.htm\">Set up a Campus/Program Tour at Ferris State</a><br><br>" +
        "We appreciate you playing our game! Please let us know what you think and how we can make it better by completing our feedback survey.<br><br>" +
        "<a href=\"https://ferrisdsgn.typeform.com/to/hIYzD9Jv\">Feedback Survey</a>";
    string compiledMessage;
    string careerInfo = "Salary<br>Description<br><br>";

    //player data
    string Name;
    string Email;
    string Field;
    string Career;
    string Color;
    string Duration;
    //tokens
    string TokenA, TokenG, TokenB, TokenM, TokenD, TokenP;
    //spaces
    string YTB, DYK, CP, BC, Normal;
    int Placement;

    //data tracking
    [SerializeField]
    readonly string postURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdOurHMy2joAjqGWQZaCpMzSxhaqo7eR9auIkD22Jlsea-qew/formResponse";

    void Start()//find GameManager so that the script can be attached literally anywhere and it doesn't matter (as long as the GameManager has all the data we need)
    {
        manager = FindObjectOfType<GameManager>();
    }

    void jobInfo(string career)
    {
        //fills out the careerInfo (salary + description)
        switch (career)//fill out
        {
            case "Advertising Account Manager":
                careerInfo = "Average Salary: $62,262/year<br>" +
                    "Advertising Account Managers work for advertising agencies developing advertising strategies and campaigns for manufacturing, retailing, and service businesses. They work with advertising \"creatives\" like designers, " +
                    "copy writers, media production companies, and networks/magazines.<br><br>";
                break;
            case "Brand/Product Manager":
                careerInfo = "Average Salary: $132,840/year<br>" +
                    "Brand or Product Managers develop and execute the firm's product, place (distribution), price, and promotion strategies to maximize sales, profits, market share, and customer satisfaction. " +
                    "Marketing Managers work with advertising and promotion agencies to promote the firm's or organization's products and services.<br><br>";
                break;
            case "Sales Professional":
                careerInfo = "Average Salary: $62,080/year<br>" +
                    "Sales representatives generally work for manufacturers, wholesalers, or business service firms, selling goods or services to businesses, government agencies, and other organizations. " +
                    "They contact customers, explain product features, and answer any questions that their customers may have. When working with retailers, they may help arrange promotional programs, store displays, and advertising.<br><br>";
                break;
            case "Marketing Research Specialist":
                careerInfo = "Average Salary: $50,500/year<br>" +
                    "The duties of a marketing research specialist include conducting market research to establish customer trends & habits and assisting with the analyses of marketing data, including campaign results, conversion rates, " +
                    "and online traffic in order to improve future marketing strategies and campaigns. They perform other duties when needed.<br><br>";
                break;
            case "Marketing Director":
                careerInfo = "Average Salary: $115,000/year<br>" +
                    "Marketing Directors evaluate and develop our marketing strategy and marketing plan. They plan, direct, and coordinate marketing efforts. They communicate the marketing plan and research demand for " +
                    "our products and services.<br><br>";
                break;
            case "Sales Manager":
                careerInfo = "Average Salary: $74,750/year<br>" +
                    "Sales managers lead a sales team by providing guidance, training, and mentorship, setting sales quotas and goals, creating sales plans, analyzing data, assinging sales territories, " +
                    "and building their team.<br><br>";
                break;
            case "Freelance Writer":
                careerInfo = "Average Salary: $49,400/year<br>" +
                    "A freelance writer's job responsibilities involve journal publishing, copy editing, proofreading, indexing, and even graphic designing. Freelance writers are involved in creating works on their own initiative, " +
                    "keeping the copyright of their works, and selling rights to publishers.<br><br>";
                break;
            case "Healthcare Marketer":
                careerInfo = "Average Salary: $84,000/year<br>" +
                    "Healthcare marketing professionals, also called marketing managers, directors, or coordinators, are responsible for developing and executing marketing plans for hospitals, nursing homes, " +
                    "outpatient care centers, and other medical facilities.<br><br>";
                break;
            case "Graphic Media Technician":
                careerInfo = "Average Salary: $49,000/year<br>" +
                    "Graphic Media Technicians help develop concepts for projects and prepare production materials for press, electronic, or multimedia publishing. You may work for publishing, communications, advertising, " +
                    "marketing, printing, or multimedia companies.<br><br>";
                break;
            case "Graphic Media Technical Sales Representativ":
                careerInfo = "Average Salary: $49,000/year<br>" +
                    "Graphic Media Technical Sales Representative responsibilities include: selling products and servies using solid arguments to prospective customers, performing cost-benefit analyses of existing and potential " +
                    "customers, maintaining positive business relationships to ensure future sales, and helping inform consumers of processes and related technologies.<br><br>";
                break;
            case "Customer Service Project Manager":
                careerInfo = "Average Salary: $75,000/year<br>" +
                    "Project managers are the people in charge of a specific project or projects within a company. As the project manager, your job is to plan, budget, oversee, and document all aspects of the specific project " +
                    "you are working on. Project managers might work by themselves or be in charge of a team to get the job done.<br><br>";
                break;
            case "Business Data Analyst":
                careerInfo = "Average Salary: $69,252/year<br>" +
                    "Business Data Analysts perform routine business analysis using various techniques, e.g. statistical analysis, explanatory and predictive modeling, and data mining. They research best practices and " +
                    "support developing the solutions and recommendations for the current business operations.<br><br>";
                break;
            case "Market Research Analyst":
                careerInfo = "Average Salary: $58,000/year<br>" +
                    "Market Research Analysts perform research and gather data to help a company market its products or services. They gather data on consumer demographics, preferences, needs, and buying habits.<br><br>";
                break;
            case "System Architect":
                careerInfo = "Average Salary: $105,000/year<br>" +
                    "System Architects devise, build, and maintain networking and computer systems. Communication is a key skill for system architects; job duties for this position include ensuring that client and company " +
                    "needs are met, offering technical support, and creating instillation instructions for users.<br><br>";
                break;
            case "Creative Director":
                careerInfo = "Average Salary: $132,770/year<br>" +
                    "A Creative Director is in charge of the creative department at advertising and marketing companies. Their duties include planning company advertisements, monitoring brand campaigns, revising presentations, " +
                    "and shaping brand standards.<br><br>";
                break;
            case "Research Director":
                careerInfo = "Average Salary: $117,000/year<br>" +
                    "Research Directors manage the research budget and the allocation of funds. They design methods for evaluating the effectiveness of research programs and oversee the operation of laboratories and research " +
                    "sites, ensuring compliance with institutional and governmental regulations.<br><br>";
                break;
            case "Media Planner":
                careerInfo = "Average Salary: $54,000/year<br>" +
                    "Media Planners produce action plans for advertising campaigns from pre-defined marketing objectives. They select media platforms that best suit the brand of product that will be advertised. Typical " +
                    "responsibilities of the job include producing financial and media plans & forecasts.<br><br>";
                break;
            case "User Experience Designer":
                careerInfo = "Average Salary: $90,700/year<br>" +
                    "UX Designer responsibilities include: conducting user research and testing, developing wireframes and task flows based on user needs, and collaborating with designers and developers to create " +
                    "intuitive, user-friendly software.<br><br>";
                break;
            case "User Interface Designer":
                careerInfo = "Average Salary: $80,500/year<br>" +
                    "User Interface (UI) Designers work closely with User Experience (UX) Designers and other design specialists. Their job is to make sure that every page and every step a user will experience in their " +
                    "interaction with the finished product will conform to the overall vision created by UX Designers.<br><br>";
                break;
            case "Content Strategist":
                careerInfo = "Average Salary: $72,500/year<br>" +
                    "Creative professionals in this role oversee content requirements and create content strategy deliverables across a project life cycle. The Content Strategist is often in charge of creating and maintaining " +
                    "editorial calendars, style guides, taxonomies, metadata frameworks, and content migration plans.<br><br>";
                break;
            case "Corporate Communications Manager":
                careerInfo = "Average Salary: $70,401/year<br>" +
                    "Communication Managers are in charge of overseeing all internal and external communications for a company, ensuring its message is consistent and engaging. Also known as a Communications Director, their " +
                    "main duties include preparing detailed media reports, press releases, and marketing materials.<br><br>";
                break;
            case "Public Relations Director":
                careerInfo = "Average Salary: $82,800/year<br>" +
                    "Public Relations Directors develop and execute strategies that are intended to create and uphold a positive public image for clients. By working and forming relationships with various members of the " +
                    "media, government, and public, directors generate new business oppportunities.<br><br>";
                break;
            default:
                careerInfo = "N/A";
                break;
        }//switch
    }//jobInfo()



    IEnumerator SendMailRequestToServer(string toName, string toEmail, string toCareer, int toPlacement)
    {
        //get career text
        jobInfo(toCareer);

        //differencees in email for first and other places
        if (toPlacement == 1)
        {
            compiledMessage = "Hey " + toName + messagePart1 + "You chose " + toCareer + messagePart2 + careerInfo + messagePart3;
        }
        else
        {
            compiledMessage = "Hey " + toName + ",<br><br>You chose " + toCareer + messagePart2 + careerInfo + messagePart3;
        }

        // Setup form responses
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("toEmail", toEmail));
        form.Add(new MultipartFormDataSection("message", compiledMessage));

        UnityWebRequest www = UnityWebRequest.Post(webhostURL, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Error");
        }
        else
        {
            Debug.Log("Sent email to " + toEmail);
        }
    }



    IEnumerator Post(string nameIn, string emailIn, string fieldIn, string careerIn, string colorIn, string tokenAIn, string tokenGIn, string tokenBIn, string tokenMIn, string tokenDIn, string tokenPIn, string ytbIn, string dykIn, string cpIn, string bcIn, string normalIn)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        //look for the sections in the URL that require input. Tutorial to find that value here: https://www.youtube.com/watch?v=z9b5aRfrz7M&ab_channel=LuzanBaral
        form.Add(new MultipartFormDataSection("entry.1774318415", nameIn));
        form.Add(new MultipartFormDataSection("entry.447813241", emailIn));
        form.Add(new MultipartFormDataSection("entry.1774298051", fieldIn));
        form.Add(new MultipartFormDataSection("entry.1309134014", careerIn));
        form.Add(new MultipartFormDataSection("entry.906285824", colorIn));

        //tokens
        form.Add(new MultipartFormDataSection("entry.297539896", tokenAIn));
        form.Add(new MultipartFormDataSection("entry.285011331", tokenGIn));
        form.Add(new MultipartFormDataSection("entry.1840331461", tokenBIn));
        form.Add(new MultipartFormDataSection("entry.621689233", tokenMIn));
        form.Add(new MultipartFormDataSection("entry.1409755334", tokenDIn));
        form.Add(new MultipartFormDataSection("entry.1815462484", tokenPIn));

        //spaces
        form.Add(new MultipartFormDataSection("entry.122754949", ytbIn));
        form.Add(new MultipartFormDataSection("entry.855798970", dykIn));
        form.Add(new MultipartFormDataSection("entry.1505258852", cpIn));
        form.Add(new MultipartFormDataSection("entry.150968286", bcIn));
        form.Add(new MultipartFormDataSection("entry.483335758", normalIn));

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent player data");
    }

    IEnumerator PostGameData(string durationIn)
    {
        //wait two seconds so the organization works in the Google Sheet
        yield return new WaitForSeconds(2);

        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("entry.806798460", durationIn));

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);
        www.SetRequestHeader("Access-Control-Allow-Credentials", "true");
        www.SetRequestHeader("Access-Control-Allow-Origin", "*");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent game data");
    }

    public void SendData()
    {
        manager = FindObjectOfType<GameManager>();
        Debug.Log("SendData() called");
        //iterate through the list of players for their info
        for (int i = 0; i < manager.currPlayers; ++i)
        {
            Debug.Log("Getting Player " + (i + 1));
            Name = manager.players[i].GetComponent<PlayerInfo>().playerName;
            // if email is blank, enter "Not Entered" for filler String
            if (manager.players[i].GetComponent<PlayerInfo>().email != "") Email = manager.players[i].GetComponent<PlayerInfo>().email;
            else Email = "Not Entered";
            if (manager.players[i].GetComponent<PlayerInfo>().fieldChoice != "") Field = manager.players[i].GetComponent<PlayerInfo>().fieldChoice;
            else Field = "Not Selected";
            Color = manager.players[i].GetComponent<PlayerInfo>().avatar.name;
            Color = Color.Substring(0, Color.IndexOf("Sit"));
            Placement = manager.players[i].GetComponent<PlayerInfo>().place;

            if (manager.players[i].GetComponent<PlayerInfo>().careerChoice != null) Career = manager.players[i].GetComponent<PlayerInfo>().careerChoice.name;
            else Career = "Not Selected";

            switch (Career)
            {
                case "jc-blue1":
                    Career = "Advertising Account Manager";
                    break;
                case "jc-blue2":
                    Career = "Brand/Product Manager";
                    break;
                case "jc-blue3":
                    Career = "Sales Professional";
                    break;
                case "jc-blue4":
                    Career = "Marketing Research Specialist";
                    break;
                case "jc-blue5":
                    Career = "Marketing Director";
                    break;
                case "jc-blue6":
                    Career = "Sales Manager";
                    break;
                case "jc-blue7":
                    Career = "Freelance Writer";
                    break;
                case "jc-blue8":
                    Career = "Healthcare Marketer";
                    break;
                case "jc-green1":
                    Career = "Graphic Media Technician";
                    break;
                case "jc-green2":
                    Career = "Graphic Media Technical Sales Representativ";
                    break;
                case "jc-green3":
                    Career = "Customer Service Project Manager";
                    break;
                case "jc-pink1":
                    Career = "Business Data Analyst";
                    break;
                case "jc-pink2":
                    Career = "Market Research Analyst";
                    break;
                case "jc-pink3":
                    Career = "System Architect";
                    break;
                case "jc-purple1":
                    Career = "Creative Director";
                    break;
                case "jc-purple2":
                    Career = "Research Director";
                    break;
                case "jc-purple3":
                    Career = "Media Planner";
                    break;
                case "jc-red2":
                    Career = "User Experience Designer";
                    break;
                case "jc-red3":
                    Career = "User Interface Designer";
                    break;
                case "jc-yellow1":
                    Career = "Content Strategist";
                    break;
                case "jc-yellow2":
                    Career = "Corporate Communications Manager";
                    break;
                case "jc-yellow4":
                    Career = "Public Relations Director";
                    break;
                default:
                    Career = "Not Selected";
                    break;
            }//switch


            //tokens
            TokenA = manager.players[i].GetComponent<PlayerInfo>().tokens[5].ToString();
            TokenG = manager.players[i].GetComponent<PlayerInfo>().tokens[1].ToString();
            TokenB = manager.players[i].GetComponent<PlayerInfo>().tokens[3].ToString();
            TokenM = manager.players[i].GetComponent<PlayerInfo>().tokens[0].ToString();
            TokenD = manager.players[i].GetComponent<PlayerInfo>().tokens[2].ToString();
            TokenP = manager.players[i].GetComponent<PlayerInfo>().tokens[4].ToString();

            //spaces
            YTB = manager.players[i].GetComponent<PlayerInfo>().spaces[0].ToString();
            DYK = manager.players[i].GetComponent<PlayerInfo>().spaces[1].ToString();
            CP = manager.players[i].GetComponent<PlayerInfo>().spaces[2].ToString();
            BC = manager.players[i].GetComponent<PlayerInfo>().spaces[3].ToString();
            Normal = manager.players[i].GetComponent<PlayerInfo>().spaces[4].ToString();

            Debug.Log("Starting Coroutine");
            //StartCoroutine(Post(Name, Email, Field, Career, Color, TokenA, TokenG, TokenB, TokenM, TokenD, TokenP, YTB, DYK, CP, BC, Normal));
            if (Email != "" && Email == "Not Entered") StartCoroutine(SendMailRequestToServer(Name, Email, Career, Placement));
        }

        //send Duration
        Duration = ((manager.gameTime) / 60f).ToString();
        //StartCoroutine(PostGameData(Duration));
    }//Send()
}
