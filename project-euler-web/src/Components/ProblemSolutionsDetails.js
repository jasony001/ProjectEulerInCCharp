import React from "react";
import styles from "./SolutionsDetails.module.css";

const ProblemSolutionsDetails = ({ problemSolutions }) => {
console.log(problemSolutions)

    return (
        <div>
            
            {problemSolutions && (
                <>
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
                        {problemSolutions.solutions.map((s) => (
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
                                <div className={styles["solution-source-code"]}>
                                    <pre>
                                        {s.solutionCodes
                                            .sort(
                                                (a, b) =>
                                                    a.lineNumber > b.lineNumber
                                            )
                                            .map((c) => (
                                                <div key={c.lineNumber}>
                                                    {c.lineNumber} {c.code}
                                                </div>
                                            ))}
                                    </pre>
                                </div>
                            </div>
                        ))}
                    </div>
                    {/* <button onClick={saveAndRetrieveProblemSolutions}>Save</button> */}
                </>
            )}
        </div>
    );
};

export default ProblemSolutionsDetails;
