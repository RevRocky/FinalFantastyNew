using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Friend Is Modern AI
 * Friend Likes You.
 * But, Friend like Victory More
 * Friend Never Makes Mistake. Friend Master Chef
 * Author: Rocky Petkov
 */
public class Friend : MonoBehaviour {

	// Reference to meal art directory
	private const string MEALS_DIR = "Art" + Path.DirectorySeparatorChar + "Meal" + Path.DirectorySeparatorChar;

	// The Min and Max of bias. Set in editor!
	public float BIAS_MIN;
	public float BIAS_MAX;
	public TextAsset MEAL_LIST_FILE;		// A text file created at build time with the tags each of the meals listed
	public float OVERPOWERING_FLAVOUR_THRESHOLD;
	public float PREMIUM_INGREDIENT_THRESHOLD;

	private static int NUM_STATS = 6;
	// References to the two known judges
	private Judge judgeOne;
	private Judge judgeTwo;
	private float[] decisionMatrix = {1, 1, 1, 1, 1, 1};	// The weights the AI will use to determine the best meal to make.

	private PlayerSubmission aiSubmission;					// The submission the AI will make 
	Random RNG;						

	// This method must run after the Judges have been initialised and added to the scene
	void Start () {
		RNG = new Random();
		DatabaseEntry optimalMeal;

		getJudgeInfo();
		modifyDecisionWeights();							// Read in the judges preferences + Random AI Bias
		optimalMeal = findOptimalMeal();									// It shall be optimal. Or that's what the AI thinks.
		aiSubmission = constructMeal(optimalMeal);
	}

	/*
	 * Takes the average of both judges weights for each
	 * stat and then applies a random AI-bias weight on
	 * those weights
	 */
	private void modifyDecisionWeights() {
		int stat;
		float biasArray[] = generateRandomFloats(NUM_STATS, BIAS_MIN, BIAS_MAX);
		float judgeOneStats[] = judgeOne.getStatModifiers();
		float judgeTwoStats[] = judgeTwo.getStatModifiers();

		// Loop through. Each position is 1 * Judge A mod * Judge 2 mod * bias!
		for (stat = 0; stat < NUM_STATS; stat++) {
			decisionMatrix[i] *= (judgeOneStats[i] * judgeTwoStats[i] * biasArray);		// Updating weights
		}
	}

	// Generates n random floats. Returns it in an array
	// TODO put in utilities class!
	private generateRandomFloats(int numFloats, float min, float max) {
		float[] randomFloats = new float[numFloats];
	
		// Loop through and generate dem puppies
		for (int i = 0; i < numFloats; i++) {
			randomFloats[i] = (float) RNG.NextDouble() * (max - min) + min
		}
		return randomFloats;
	}

	// Searches through All Meals in the Game. Returns copy of database entry with highest weighted score
	private DatabaseEntry findOptimalMeal() {
		float score;		// Current score of the meal we're looking at
		DatabaseEntry optimalMeal;	// Best meal we've found so far!
		DatabaseEntry mealEntry;	// Current meal we're looking at
		string[] textFileDelimiters = {'\n'};

		string[] meals = MEAL_LIST_FILE.text.Split(textFileDelimiters);
		float maxScore = 0;		// Largest score we've found so far

		// Loop thrugh. Finding the max score.
		foreach (string meal in meals) {
			mealEntry = Database.instance.searchByTag(meal.TrimEnd()); 	// Search for the meal. TrimEnd call for safe measure
			score = calculateMealScore(mealEntry);
			
			// If it's better, note it. Else... keep looking
			if (score > maxScore) {
				maxScore = score;
				optimalMeal = mealEntry;
			}
		}
		return optimalMeal;		// The best... or so he thinks!
	}

	// Calculates a simple weighted score of a meal based off
	// of raw stats!
	private float calculateMealScore(DatabaseEntry meal) {
		float score = 0;
		int i = 0;

		// Loop through, summing up each meal's score
		for (; i < NUM_STATS; i++) {
			score += decisionMatrix[i] * (float) meal.stats[i];		// Simple weighted sum!
		}
		return score;
	}	

	/*
	 * Applies ingredient based stat modifiers to optimalMeal
	 * Creates a Submission with this meal and a random
	 * chance of overpowering flavour
	 */
	private PlayerSubmission constructMeal(optimalMeal) {
		byte[] finalStats = addIngredients(optimalMeal);
		byte[] overpoweringMods;

		// Assuming a uniform distrobution of random floats between 0-1
		if (RNG.NextDouble >= OVERPOWERING_FLAVOUR_THRESHOLD) {
			overpoweringMods = OverpoweringFlavour.generateModifiers();		// If we pass the check, include overpowering flavour
		}
		else {
			overpoweringMods = {0, 0, 0, 0, 0, 0};							// Else no modifiers!
		}

		// Construct a new Player Submission!
		return new PlayerSubmission("FRIEND", optimalMeal.name, finalStats, overpoweringMods, IMG2Sprite.instance.LoadNewSprite(MEALS_DIR + optimalMeal.artLocation));
	}

	// Adds each ingedient's stats on to the final meal.
	// Each ingredient has a small chance of being a 
	// "superior" ingredient
	private byte[] addIngredients(DatabaseEntry meal) {
		DatabaseEntry ingredient;	// Reference to the current ingredient we are looking at

		string ingredientList = meal.tag.Split(";");	// ';' seperates each ingredient
		byte statSum[] = meal.stats.Clone();			// Get clone of the meal's stats!

		// Loop through adding each ingredient
		foreach (string ingredientTag in ingredientList) {
			try {
				ingredient = Database.instance.searchByTag(ingredientTag.TrimEnd());

				//TODO Implement Step Up Attribute. Same as tag of one step up!
				// If a step up exists, and the check passes, use it!
				if (!ingredient.stepUp.Equals("N/A") && RNG.NextDouble() > PREMIUM_INGREDIENT_THRESHOLD) {
					ingredient = Database.instance.searchByTag(ingredient.stepUp);
				}
				statSum = statSum.Zip(ingredient.stats, (x, y) => x + y).ToArray();		// So Functional! Adding ingredients stats. Wao!
			}
			catch (ItemNotFound e) {
				Debug.Log("Ingredient unable to be found");		// TODO Reference name of the ingredient
				// Do nothing and go around the loop
			}	// End Try Catch
		}	// End foreach
		return statSum;		// Returning the sum of our stats!
	}

}
