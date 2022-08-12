import React from "react";
import styles from "./ProblemSelector.module.css";
import ProblemSolutionsDetails from "./ProblemSolutionsDetails";

const ProblemSelector = () => {
  const [problemId, setProblemId] = React.useState("");
  const [problemSolutions, setProblemSolutions] = React.useState(null);
  const [apiErrors, setApiErrors] = React.useState("");
  const [showProblemIdList, setShowProblemIdList] = React.useState(false);
  const [availableProblemIdList, setAvailableProblemIdList] = React.useState([
    1, 2, 5,
  ]);

  const handleChange = (e) => {
    setShowProblemIdList(true);
    setProblemId(e.target.value);
  };

  const retriveProblemSolutions = async () => {
    setApiErrors("");
    let response = await fetch(
      `https://localhost:5001/CalulatedProblemSolutions?problemId=${problemId}`
    );
    let ps = await response.json();

    if (response.status !== 200) {
      throw new Error(
        ps["GetCalulatedProblemSolutions"]
          ? ps["GetCalulatedProblemSolutions"][0]
          : "Error calculating problem solutions"
      );
    }

    return ps;
  };

  const calculateProblemSolution = (e) => {
    e.preventDefault();
    retriveProblemSolutions()
      .then((ps) => setProblemSolutions(ps))
      .catch((err) => {
        setApiErrors(err.message);
        setProblemSolutions(null);
      });
  };

  React.useEffect(() => {
    setAvailableProblemIdList([]);
    fetch(`https://localhost:5001/AvailableProblemIdList`)
      .then((r) => r.json())
      .then((d) => setAvailableProblemIdList(d));
  }, []);

  return (
    <div
      onClick={() => {
        console.log("div clicked");
        setShowProblemIdList(false);
      }}
      className={styles.container}
    >
      <h1>Project Euler</h1>
      <form
        onSubmit={calculateProblemSolution}
        className={styles.form}
        autoComplete="off"
      >
        <label style={{ "marginRight": "20px" }}>Problem Id:</label>
        <input
          id="problemId"
          value={problemId}
          onChange={handleChange}
          onClick={(e) => {
            console.log("focus");
            setShowProblemIdList(true);
            e.stopPropagation();
          }}
          style={{ "marginRight": "20px" }}
        ></input>
        <button>Show Solutions</button>
        {apiErrors && <div className={styles.error}>{apiErrors}</div>}
        {showProblemIdList && (
          <div className={styles["problem-id-list"]}>
            {availableProblemIdList
              .filter(p => p !== "xx")
              .filter((p) => (p + "").indexOf(problemId) >= 0)
              .sort((a, b) => a * 1 > b * 1)
              .map((p) => {
                return (
                  <div
                    className={styles["available-problem-id"]}
                    key={p}
                    onClick={() => setProblemId(p)}
                  >
                    {p}
                  </div>
                );
              })}
          </div>
        )}
      </form>
      {problemSolutions && (
        <div className={styles["solutions"]}>
          <ProblemSolutionsDetails problemSolutions={problemSolutions} />
        </div>
      )}
    </div>
  );
};

export default ProblemSelector;
