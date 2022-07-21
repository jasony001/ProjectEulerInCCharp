import React from "react";
import styles from "./SolutionsDetails.module.css";

const ProblemSolutionsDetails = ({ problemSolutions }) => {
    const [sourceCodeLines, setSourceCodeLines] = React.useState(null);

    React.useEffect(() =>{
        fetch("https://localhost:5001/GitHubUserInfo/AccessToken")
        .then(r => r.json())
        .then(d => {
            let pid = problemSolutions.id * 1;
            if (pid < 0) return;
    
            let lowerBound = 1;
            let upperBound = 50;
    
            while(pid < lowerBound || pid > upperBound){
                lowerBound += 50;
                upperBound += 50;
            }
    
            let contentPath = `/ProjectEulerLib/ProblemSolvers/Problem${lowerBound}_${upperBound}/Problem${problemSolutions.id}Solver.cs`
            let apiUrl = `https://api.github.com/repos/jasony001/ProjectEulerInCSharp/contents/${contentPath}`;

            fetch(apiUrl, {
                method:"GET",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                    "User-Agent": 'localhost web',
                    'Authorization': `token ${d.token}` 
                }
            })
            .then(r => {
                setSourceCodeLines(null);
                if (r.status === 200){
                    return r.json();
                } else {
                    throw new Error("not pushed yet");
                }
            })
            .then(d => {
                setSourceCodeLines(atob(d.content.replaceAll('\\n', '')))
            }).catch(err => console.log(err.message));
        });
    }, [problemSolutions.id])

    if (!problemSolutions) return <div> no solutions yet</div>

    return (
        <div>
            <div className={styles.details}>
                <div className={styles["problem-title"]}>
                    Problem # {problemSolutions.id} {problemSolutions.title}
                </div>
                <div className={styles.description}>
                    {problemSolutions.description
                        .split("\n")
                        .map((i, index) => (
                            <p key={index}>{i}</p>
                        ))}
                </div>
                {
                    problemSolutions.solutions.map((s) => (
                    <div className={styles.solution} key={s.version}>
                        <div className={styles["solution-header"]}>
                            solution {s.version}
                        </div>
                        <div className={styles["solution-summary"]}>
                        <div>Answer: {s.answer.split("\n")
                        .map((i, index) => (
                            <p key={index}>{i}</p>
                        ))}</div>
                        <div>
                            Calculation Time: {s.testRunElapsedTime}
                        </div>
                        <div>Brief description: {
                            s.description
                                .split("\n")
                                .map((i, index) => (
                                    <p key={index}>{i}</p>
                                ))
                            
                        }</div>
                        </div>
                    
                        
                        
                        
                    </div>
                )
                )}
            </div>
            <div style={{"text-align":"start"}}><a href="https://github.com/jasony001/ProjectEulerInCSharp" target="_blank" rel="noreferrer">Github Repository</a></div>
            { !sourceCodeLines && <div style={{"text-align":"start"}}> solutions not pushed to github yet </div>}
            { sourceCodeLines && (
                <div className={styles["solution-source-code"]}>
                    <h3>Source Code</h3>
                    <pre>
                        {sourceCodeLines}
                    </pre>
                </div>
            )}
        </div>
    );
};

export default ProblemSolutionsDetails;
