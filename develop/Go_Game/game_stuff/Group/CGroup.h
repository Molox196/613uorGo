/*
 * CGroup.h
 *
 *  Created on: 1 במאי 2015
 *      Author: Molox
 */

#ifndef CGROUP_H_
#define CGROUP_H_

#include "../stone/CStone.h"

class CGroup {
public:

	std::list<CStone> m_stones;
	EStone_State m_groupState;

	CGroup();
	virtual ~CGroup();

	/**
	 * init the class
	 * init the m_stone with the seed, set the group state (black\white)
	 * delete  and return the amount of deleted stones.
	 *
	 */
	EGameReturn init(CStone * initSeed, int * killed);

	EGameReturn killGroup();

	EGameReturn find (int * isAlive, CStone * aStone); //later think abot and static alive flag

};

#endif /* CGROUP_H_ */
