/*
 * CStone.h
 *
 *  Created on: 1 במאי 2015
 *      Author: Molox
 */

#ifndef CSTONE_H_
#define CSTONE_H_

#include <list>

/*

struct SPoint
{
	int x;
	int y;
};
*/

enum EStone_State
{
	eSts_Null 	= 0,
	eSts_Black	= 1,
	eSts_White 	= - eSts_Black, // for later check: white is (-1)*black
	eSts_Ko 	= 9, // blocked, turn null after 1 turn;
};

enum EGameReturn
{
	eGameReturn_Success,
	eGameReturn_InvalidPointer,
	eGameReturn_InvalidValue,
	eGameReturn_ // TODO: delete before release
};

enum Elink
{
	eLS_up = 0,
	eLS_down,
	eLS_left,
	eLS_right,
	eLS_count
};

class CStone {
public:

	// the state (b/w/null/blocked)
	EStone_State m_state;

	CStone();

	virtual ~CStone();

	//init linked stones
	EGameReturn setLinkedStone(CStone * up, CStone * down, CStone * right, CStone * left);
	// check and return a list of linked stone (to this one)
	EGameReturn getlinkedstones(std::list<CStone> * stonelist);

	/**
	 * put stone (b\w)
	 * decrease the liberties of all linked stones
	 *
	 */
	EGameReturn putStone(EStone_State aState);


	/**
	 * remove stone (b\w)
	 * increase the liberties of all linked stones
	 *
	 */
	EGameReturn removeStone();

	inline int getLiberties()
	{
		return m_liberties;
	}

private:
	// neighbors
	CStone * m_linkedStone[eLS_count];
	int m_liberties;

/*
	//the position
	SPoint * m_point;*/
};

#endif /* CSTONE_H_ */
